using Microsoft.AspNetCore.Mvc;
using Parcial.Domain;
using Parcial.Service;

namespace Parcial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadorController:ControllerBase
    {
        private IJugadorService jugadorService;

        public JugadorController(IJugadorService jugadorService){
            this.jugadorService = jugadorService;
        }

        [HttpGet]
        public ActionResult Get(){
            return Ok(
                jugadorService.FindAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Jugador jugador)
        {
            return Ok(
                jugadorService.Create(jugador)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Jugador jugador)
        {
            return Ok(
                jugadorService.Update(jugador)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                jugadorService.Delete(id)
            );
        }
    }
}