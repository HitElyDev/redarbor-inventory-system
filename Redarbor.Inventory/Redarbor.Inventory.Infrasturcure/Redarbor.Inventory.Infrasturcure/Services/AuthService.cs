using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Redarbor.Inventory.Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace Redarbor.Inventory.Infrastructure.Services;
public class AuthService : IAuthService
{
    private readonly IConfiguration _config;
    public AuthService(IConfiguration config)
    {
        _config = config;
    }
    public string GenerateToken(string username)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[] { new Claim(ClaimTypes.Name, username) };
        var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(60), signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
