using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EvoMarket.Auth.Service.Interfaces.ServiceInterfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EvoMarket.Auth.Service.Services;

public class TokenService:ITokenService
{
    private readonly IConfiguration _configurationManager;

    public TokenService(IConfiguration configurationManager)
    {
        _configurationManager = configurationManager;
    }
    public string GetToken()
    {
        string key = _configurationManager.GetSection("Authentication")["SecurityKey"];
        string issuer = _configurationManager.GetSection("Authentication")["Issuer"];
        string audience = _configurationManager.GetSection("Authentication")["Audience"];
        int expiresInMinutes = _configurationManager.GetSection("Authentication").GetValue<int>("ExpireAtInMinutes");
        
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, "Obid23"),
            new Claim("gender", "m")
        };

        var jwtSecurityToken = new JwtSecurityToken(
            claims: claims,
            signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256),
            issuer: issuer,
            audience: audience,
            expires: DateTime.Now.AddMinutes(expiresInMinutes)
        );

        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }
}