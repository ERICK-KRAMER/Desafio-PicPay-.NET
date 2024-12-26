using Microsoft.EntityFrameworkCore.Storage;
using PicPay.Model.Entity;

namespace PicPay.Data.Repository.Transfer;

public interface ITransferRepository
{
    Task AddTransferAsync(TransferEntity transfer);
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task CommitAsync();
}