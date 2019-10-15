using Microsoft.AspNetCore.Mvc;
using Parcial.Domain;
using Parcial.Service;
using Parcial.Repository.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Parcial.Domain.helper;
using System;
using Microsoft.Extensions.Configuration;

namespace Parcial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadorController:ControllerBase
    {
        private IJugadorService jugadorService;
        private readonly IConfiguration configuration;
        // private TokenAdministrador tokenAdministrador;

        public JugadorController(IJugadorService jugadorService, IConfiguration configuration){
            this.jugadorService = jugadorService;
            this.configuration = configuration;
        }

        [HttpGet]
        public ActionResult Get(){
            return Ok(jugadorService.FindAll());
        }

        [HttpPost]
        public ActionResult Post([FromBody] Jugador jugador)
        {
            var correoExist = jugadorService.EmailExist(jugador.Cuenta.Correo);
            if(correoExist){
                return BadRequest("El correo ya esta en uso");
            }

            return Ok(jugadorService.Create(jugador));
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] Cuenta cuenta){
            var jugador = jugadorService.Login(cuenta.Correo, cuenta.Password);
            if(jugador == null){
                return BadRequest("Usuario y/o contraseña incorrectas");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenSettings = configuration.GetSection("tokenManagement");
            var tokenAdministrador = tokenSettings.Get<TokenAdministrador>();
            var key = Encoding.ASCII.GetBytes(tokenAdministrador.SecretKey);
            // Console.Write("Gaaa: key-> "+(key));
            var TokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity( new Claim[]{
                    new Claim( ClaimTypes.Name, jugador.JugadorId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(TokenDescriptor);
            jugador.Token = tokenHandler.WriteToken(token);
            jugador.JugadorId = 0;
            return Ok(jugador);
            // return Ok(jugadorService.Login(cuenta.Correo, cuenta.Password));
        }
        [HttpPut]
        public ActionResult Put([FromBody] Jugador jugador)
        {
            return Ok(jugadorService.Update(jugador));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(jugadorService.Delete(id));
        }

    }
}