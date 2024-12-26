using System.ComponentModel.DataAnnotations;

namespace PicPay.Model.Request;

public class TransferRequest
{
    [Required(ErrorMessage = "Sender is required")]
    public Guid SenderId { get; set; }
    
    [Required(ErrorMessage = "Receiver is required")]
    public Guid ReceiverId { get; set; }
    
    [Required(ErrorMessage = "Amount is required")]
    public decimal Value { get; set; }
}