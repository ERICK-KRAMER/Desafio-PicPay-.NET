using PicPay.Data.Repository.Wallet;
using PicPay.Model.Entity;
using PicPay.Model.Request;
using PicPay.Model.Response;

namespace PicPay.Services.Wallet;

public class WalletService : IWalletService
{
    private readonly IWalletRepository _walletRepository;

    public WalletService(IWalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }
    
    public async Task<Result<bool>> ExecuteAsync(WalletRequest request)
    {
        // verificar se a carteira já existe
        var WalletAlreadyExist = await _walletRepository.GetByCpfAsync(request.Cpf, request.Email);

        if (WalletAlreadyExist is not null) return Result<bool>.Falied("Carteira já existente");
        
        // Craiaçao da Carteira
        var newWallet = new WalletEntity(
            request.FullName,
            request.Email,
            request.Cpf,
            request.Password,
            request.Cash,
            request.Type
        );
        
        await _walletRepository.AddAsync(newWallet);
        await _walletRepository.CommitAsync();
        
        return Result<bool>.Success(true);
    }
}