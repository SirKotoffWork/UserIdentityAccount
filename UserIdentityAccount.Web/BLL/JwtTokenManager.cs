using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace UserIdentityAccount.Web.BLL;

public class JwtTokenManager:IJwtTokenManager
{
    private readonly IConfiguration _configuration;
    
    public JwtTokenManager(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string Authenticate(string userName, string password)
    {
        if (!Data.Data.Users.Any(a => a.Key.Equals(userName) && a.Value.Equals(password)))
        {
            return null;
        }
        
        var key = _configuration.GetValue<string>("JwtConfig:Key");
        var keyBytes = Encoding.ASCII.GetBytes(key);

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
               new Claim(ClaimTypes.NameIdentifier,userName) 
            }),
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}