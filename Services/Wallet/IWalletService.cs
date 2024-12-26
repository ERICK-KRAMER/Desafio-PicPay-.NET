using PicPay.Model.Request;
using PicPay.Model.Response;

namespace PicPay.Services.Wallet;

public interface IWalletService
{
    Task<Result<bool>> ExecuteAsync(WalletRequest request);
}