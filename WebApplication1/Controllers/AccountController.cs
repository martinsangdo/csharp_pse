using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("account")]
public class AccountController : Controller
{
    private readonly AccountService _accountService;
    public AccountController(AccountService accountService)
    {
        _accountService = accountService;
    }

    [Route("profile")]
    public IActionResult registerView()
    {
        var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
        if (string.IsNullOrEmpty(email))
            return Unauthorized();
        Account savedAccount = _accountService.GetInfo(email);
        if (savedAccount != null)
        {
            ViewBag.fullname = savedAccount.fullname;
            ViewBag.email = savedAccount.email;
        }
        return View("~/Views/ogani/profile.cshtml");

    }
}
