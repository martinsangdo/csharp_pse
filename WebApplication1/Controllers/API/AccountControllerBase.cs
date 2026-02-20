using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/account")]  //
public class AccountControllerBase : ControllerBase
{
    private readonly AccountService _accountService;

    public AccountControllerBase(AccountService accountService)
    {
        _accountService = accountService;
    }

    //create with basic validation
    [HttpPost("create_with_basic_validation")]
    public IActionResult CreateAccountWithBasicValidation(CreateAccountDto dto)
    {
        _accountService.CreateAccount(dto);
        return Ok("Account Created Successfully");
    }

}