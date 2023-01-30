using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserIdentityAccount.Web.BLL;
using UserIdentityAccount.Web.Data;

namespace UserIdentityAccount.Web.Controllers;


[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class UserController:ControllerBase
{
    private readonly IJwtTokenManager _tokenManager;

    public UserController(IJwtTokenManager jwtTokenManager)
    {
        _tokenManager = jwtTokenManager;
    }
    [AllowAnonymous]
    [HttpPost("Authenticate")]
    public string Authenticate([FromBody] UserCredential credential)
    {
        var token = _tokenManager.Authenticate(credential.UserName, credential.Password);
        if (string.IsNullOrEmpty(token))
        {
            return "user is not auth";
        }

        return token;
    }
    
}