using API.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/wallet")]
public class WallteController : ControllerBase
{
    private readonly WalletService _walletService;

    public WallteController(WalletService walletService)
    {
        _walletService = walletService;
    }
    [HttpPost(Name = "/recharge")]
    public IActionResult recharge(string idcard, string username, double recharge)
    {
        return Ok(_walletService.recharge(idcard, username, recharge));
    }
}