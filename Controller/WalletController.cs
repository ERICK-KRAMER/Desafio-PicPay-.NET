using Microsoft.AspNetCore.Mvc;
using PicPay.Data.Repository.Wallet;
using PicPay.Model.Request;
using PicPay.Services.Wallet;

namespace PicPay.Controller;

[ApiController]
[Route("[controller]")]
public class WalletController : ControllerBase
{
    private readonly IWalletRepository _repository;
    private readonly IWalletService _service;

    public WalletController(IWalletRepository repository, IWalletService service)
    {
        _repository = repository;
        _service = service;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateWallte(WalletRequest request)
    {
        var result = await _service.ExecuteAsync(request);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetWallet(string cpf, string email)
    {
        var findWallet = await _repository.GetByCpfAsync(cpf, email);
        return Ok(findWallet);
    }
}