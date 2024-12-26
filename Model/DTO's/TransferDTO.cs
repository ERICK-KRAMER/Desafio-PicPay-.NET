using PicPay.Model.Entity;

namespace PicPay.Model.DTO_s;


public record TransferDTO(Guid transferId, WalletEntity sender, WalletEntity receiver, decimal value);