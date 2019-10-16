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
        private TokenService tokenService;
        // private TokenAdministrador tokenAdministrador;

        public JugadorController(IJugadorService jugadorService, IConfiguration configuration){
            this.jugadorService = jugadorService;
            this.configuration = configuration;
            tokenService = new TokenService();
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
            var userCreate = jugadorService.Create(jugador);
            if(!userCreate){
                return BadRequest("No se pudo crear el usuario intentelo de nuevo");
            }
            var jugadorDB = jugadorService.findByEmail(jugador.Cuenta.Correo);
            jugadorDB.Token = tokenService.Build(jugadorDB, configuration);
            jugadorDB.JugadorId = 0;
            return Ok(jugadorDB);
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] Cuenta cuenta){
            var jugador = jugadorService.Login(cuenta.Correo, cuenta.Password);
            if(jugador == null){
                return BadRequest("Usuario y/o contraseña incorrectas");
            }

            jugador.Token = tokenService.Build(jugador, configuration);
            jugador.JugadorId = 0;
            return Ok(jugador);
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