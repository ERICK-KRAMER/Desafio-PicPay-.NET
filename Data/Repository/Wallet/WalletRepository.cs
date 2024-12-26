using Microsoft.EntityFrameworkCore;
using PicPay.Model.Entity;

namespace PicPay.Data.Repository.Wallet;

public class WalletRepository : IWalletRepository
{
    private readonly PicPayDbContext _context;

    public WalletRepository(PicPayDbContext context)
    {
        _context = context;
    }
    
    public async Task AddAsync(WalletEntity wallet)
    {
        await _context.Wallet.AddAsync(wallet);
    }

    public async Task UpdateAsync(WalletEntity wallet)
    {
        _context.Wallet.Update(wallet);
    }

    public Task<WalletEntity?> GetByCpfAsync(string cpf, string email)
    {
        var wallet = _context.Wallet.FirstOrDefaultAsync(
            x => x.Cpf.Equals(cpf) && x.Email.Equals(email)
        );
        return wallet;
    }

    public async Task<WalletEntity?> GetByIdAsync(Guid id)
    {
        var wallet = await _context.Wallet.FindAsync(id);
        return wallet;
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}