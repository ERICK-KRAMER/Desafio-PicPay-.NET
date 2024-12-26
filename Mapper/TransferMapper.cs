using PicPay.Model.DTO_s;
using PicPay.Model.Entity;

namespace PicPay.Mapper;

public static class TransferMapper
{
    public static TransferDTO ToTransferDTO(this TransferEntity transfer)
    {
        return new TransferDTO(
            transfer.TranferId,
            transfer.Sender,
            transfer.Receive,
            transfer.Value
            
        );
    }
}