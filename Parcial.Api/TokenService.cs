using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Parcial.Domain.helper;
using Parcial.Repository.Dto;

namespace Parcial.Api
{
    public class TokenService
    {
        public TokenService(){

        }

        public string Build(UsuarioDto jugador, IConfiguration configuration){
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenSettings = configuration.GetSection("tokenManagement");
            var tokenAdministrador = tokenSettings.Get<TokenAdministrador>();
            var key = Encoding.ASCII.GetBytes(tokenAdministrador.SecretKey);
            
            var TokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity( new Claim[]{
                    new Claim( ClaimTypes.Name, jugador.JugadorId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(TokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}