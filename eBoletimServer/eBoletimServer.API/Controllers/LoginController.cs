using eBoletimServer.Domain.Models.ViewModels;
using eBoletimServer.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace eBoletimServer.API.Controllers;

[Route("Login")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly ILoginService _login;
    public LoginController(ILoginService login)
    {
        _login = login;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginModel login)
    {
        try
        {
            var result = await _login.Login(login);
            return StatusCode(result.Code, result.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}