using PicPay.Model.Entity;

namespace PicPay.Data.Repository.Wallet;

public interface IWalletRepository
{
    Task AddAsync(WalletEntity wallet);
    Task UpdateAsync(WalletEntity wallet);
    Task<WalletEntity?> GetByCpfAsync(string cpf, string email);
    Task<WalletEntity?> GetByIdAsync(Guid id);
    Task CommitAsync();
}