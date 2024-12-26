using Microsoft.AspNetCore.Mvc;
using PicPay.Model.Request;
using PicPay.Services.Authorization;
using PicPay.Services.Transfer;

namespace PicPay.Controller;

[ApiController]
[Route("[controller]")]
public class TransferController : ControllerBase
{
    private readonly ITransferService _service;
    private readonly IAuthorizationService _authorizationService;

    public TransferController(ITransferService service, IAuthorizationService authorizationService)
    {
        _service = service;
        _authorizationService = authorizationService;
    }

    [HttpPost]
    public async Task<IActionResult> Transfer(TransferRequest request)
    {
        var transfer = await _service.TransferAsync(request);

        if (!transfer.IsSuccess)
        {
            return BadRequest();
        }
        
        return Ok(transfer);
    }

    [HttpGet]
    public async Task<IActionResult> TestAuthorization()
    {
        var response = await _authorizationService.AuthorizatorAsync();
        return Ok(response);
    }
}