namespace PicPay.Services.Authorization;

public interface IAuthorizationService
{
    Task<bool> AuthorizatorAsync();
}