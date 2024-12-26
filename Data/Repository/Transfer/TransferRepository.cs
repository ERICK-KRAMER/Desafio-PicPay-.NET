using Microsoft.EntityFrameworkCore.Storage;
using PicPay.Model.Entity;

namespace PicPay.Data.Repository.Transfer;

public class TransferRepository : ITransferRepository
{
    private readonly PicPayDbContext _context;

    public TransferRepository(PicPayDbContext context)
    {
        _context = context;
    }
    
    public async Task AddTransferAsync(TransferEntity transfer)
    {
        await _context.Transfer.AddAsync(transfer);
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }
}