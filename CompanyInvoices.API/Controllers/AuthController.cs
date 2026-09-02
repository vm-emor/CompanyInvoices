using CompanyInvoices.Abstractions.Interfaces;
using CompanyInvoices.API.Services;
using CompanyInvoices.Contracts.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyInvoices.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _users;
    private readonly ITokenService _tokens;

    public AuthController(IUserRepository users, ITokenService tokens)
    {
        _users = users;
        _tokens = tokens;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _users.GetByLoginAsync(request.Login);
        if (user == null)
        {
            return Unauthorized();
        }

        if (!string.Equals(user.Value.PasswordHash, request.Password, StringComparison.Ordinal))
        {
            return Unauthorized();
        }

        var response = _tokens.Create(user.Value.UserId, user.Value.UserName);
        return Ok(response);
    }
}
