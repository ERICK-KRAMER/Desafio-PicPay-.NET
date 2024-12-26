using PicPay.Model.Enum;

namespace PicPay.Model.Entity;

public class WalletEntity
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Cpf { get; set; }
    public string Password { get; set; }
    public decimal Cash { get; private set; }
    public WalletType Type { get; set; }

    public WalletEntity(string fullName, string email, string cpf, string password, decimal cash, WalletType type)
    {
        Id = Guid.NewGuid();
        FullName = fullName;
        Email = email;
        Cpf = cpf;
        Password = password;
        Cash = cash;
        Type = type;
    }

    public void AddCredit(decimal amount)
    {
        Cash += amount;
    }

    public void AddDebit(decimal amount)
    {
        Cash -= amount;
    }
}
