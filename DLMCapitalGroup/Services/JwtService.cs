using DLMCapitalGroup.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Providers.Entities;

namespace DLMCapitalGroup.Services
{
    public class JwtService : IJwtService
    {

        private readonly IConfiguration _config;
        public JwtService(IConfiguration configuration)
        {
            _config = configuration;
        }
        public string GenerateJWTToken(Customer customer, List<string> userRoles)
        {
            //Adding user claims
            var Claims = new List<Claim>
            {
              new Claim(ClaimTypes.NameIdentifier, customer.Id),
              new Claim(ClaimTypes.Email, customer.Email),
              new Claim(ClaimTypes.Name, customer.UserName)
            };
            foreach (var role in userRoles)
            {
                Claims.Add(new Claim(ClaimTypes.Role, role));
            }
            //Set up system security
            var SymmetricSecurity = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("JWT:Key").Value));

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(Claims),
                Expires = DateTime.Today.AddDays(1),
                SigningCredentials = new SigningCredentials(SymmetricSecurity, SecurityAlgorithms.HmacSha256)
            };
            //Create token
            var SecurityTokenHandler = new JwtSecurityTokenHandler();

            var token = SecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return SecurityTokenHandler.WriteToken(token);
        }
    }
}
