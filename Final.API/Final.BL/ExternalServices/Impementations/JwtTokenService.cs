﻿using Final.BL.ExternalServices.Abstractions;
using Final.Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Final.BL.ExternalServices.Impementations;

public class JwtTokenService : IJwtTokenService
{
    private readonly IConfiguration _configuration;

    public JwtTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(AppUser existingUser)
    {
        List<Claim> claims = new List<Claim>()
            {
                new Claim("FirstName", existingUser.FirstName),
                new Claim(ClaimTypes.Name,existingUser.UserName),
                new Claim(ClaimTypes.NameIdentifier,existingUser.Id)
            };

        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(claims: claims, issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"], signingCredentials: signingCredentials, expires: DateTime.UtcNow.AddMinutes(10));
        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }
}
    

