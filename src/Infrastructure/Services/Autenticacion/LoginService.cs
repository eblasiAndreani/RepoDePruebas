using Andreani.ARQ.Pipeline.Clases;
using CrudTest.Application.Common.Interfaces.IAutenticacion;
using CrudTest.Application.UseCase.LoginABM.GetByUserPassword;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Infrastructure.Services.Autenticacion
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration configuration;
        public LoginService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public GetLoginResponse Login(string username)
        {
            var secret = configuration.GetSection("Authentication:Secret").Value;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddMonths(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new GetLoginResponse() { Token = tokenHandler.WriteToken(token) };
        }
    }
}
