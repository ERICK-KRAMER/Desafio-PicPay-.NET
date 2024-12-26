using PicPay.Model.DTO_s;
using PicPay.Model.Request;
using PicPay.Model.Response;

namespace PicPay.Services.Transfer;

public interface ITransferService
{
    Task<Result<TransferDTO>> TransferAsync(TransferRequest request);
}