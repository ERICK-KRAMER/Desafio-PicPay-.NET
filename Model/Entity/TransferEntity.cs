namespace PicPay.Model.Entity;

public class TransferEntity
{
    public Guid TranferId { get; set; }
    public Guid SerderId { get; set; }
    public WalletEntity Sender { get; set; }
    public Guid ReceiveId { get; set; }
    public WalletEntity Receive { get; set; }
    public decimal Value { get; set; }

    public TransferEntity() { }

    public TransferEntity(Guid serderId,Guid receiveId, decimal value)
    {
        TranferId = Guid.NewGuid();
        SerderId = serderId;
        ReceiveId = receiveId;
        Value = value;
    }
}