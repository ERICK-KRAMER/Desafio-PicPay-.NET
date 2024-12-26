using PicPay.Data.Repository.Transfer;
using PicPay.Data.Repository.Wallet;
using PicPay.Mapper;
using PicPay.Model.DTO_s;
using PicPay.Model.Entity;
using PicPay.Model.Enum;
using PicPay.Model.Request;
using PicPay.Model.Response;
using PicPay.Services.Authorization;
using PicPay.Services.Notification;

namespace PicPay.Services.Transfer;

public class TransferService : ITransferService
{
    private readonly ITransferRepository _transferRepository;
    private readonly IWalletRepository _walletRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly INotificationService _notificationService;
    
    public TransferService(ITransferRepository transferRepository, IWalletRepository walletRepository, IAuthorizationService authorizationService, INotificationService notificationService)
    {
        _transferRepository = transferRepository;
        _walletRepository = walletRepository;
        _authorizationService = authorizationService;
        _notificationService = notificationService;
    }
    
    public async Task<Result<TransferDTO>> TransferAsync(TransferRequest request)
    {
        //Verifica se esta autorizado a fazer a transação
        if (!await _authorizationService.AuthorizatorAsync())
        {
            return Result<TransferDTO>.Falied("Não autorisado");
        }
        
        var sender = await _walletRepository.GetByIdAsync(request.SenderId);
        var receiver = await _walletRepository.GetByIdAsync(request.ReceiverId);
        
        // verifica se o pagador ou o recebedor é null
        if (sender is null || receiver is null) return Result<TransferDTO>.Falied("Carteira não encontrada");
        
        // verifica se o pagador tem saldo positivo na conta 
        if (sender.Cash < request.Value || sender.Cash == 0) return Result<TransferDTO>.Falied("Não possui cash");
        
        // Verifica se o tipo de conta 
        if (sender.Type == WalletType.Shopkeeper) return Result<TransferDTO>.Falied("O lojista nao pode fazer transações");
        
        sender.AddDebit(request.Value);
        receiver.AddCredit(request.Value);

        var transfer = new TransferEntity(
            sender.Id,
            receiver.Id,
            request.Value
        );

        using (var transferScop = await _transferRepository.BeginTransactionAsync())
        {
            try
            {
                var updateTask = new List<Task>
                {
                    _walletRepository.UpdateAsync(sender),
                    _walletRepository.UpdateAsync(receiver),
                    _transferRepository.AddTransferAsync(transfer)
                };
                
                await Task.WhenAll(updateTask);
                await _walletRepository.CommitAsync();
                await _transferRepository.CommitAsync();
                
                await transferScop.CommitAsync();

            }
            catch (Exception)
            {
                await transferScop.RollbackAsync();
                return Result<TransferDTO>.Falied("Falha ao transfer");
            }
        }

        await _notificationService.SendNotificationAsync();
        return Result<TransferDTO>.Success(transfer.ToTransferDTO());
    }
}