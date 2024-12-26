using System.ComponentModel.DataAnnotations;
using PicPay.Model.Enum;

namespace PicPay.Model.Request;

public class WalletRequest
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string FullName { get; set; }
    
    [Required(ErrorMessage = "O email é obrigatório")]
    [EmailAddress(ErrorMessage = "Preencha com um email valido")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "O cpf é obrigatório")]
    public string Cpf { get; set; }
    
    [Required(ErrorMessage = "A senha é obrigatório")]
    public string Password { get; set; }
    
    [Required(ErrorMessage = "O Tipo é obrigatório")]
    public WalletType Type { get; set; }
    
    [Required(ErrorMessage = "Adicione o Valor da Conta")]
    public decimal Cash { get; set; }
}