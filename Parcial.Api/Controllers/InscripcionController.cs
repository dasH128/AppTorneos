using Microsoft.AspNetCore.Mvc;
using Parcial.Domain;
using Parcial.Service;

namespace Parcial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscripcionController:ControllerBase
    {
        private IInscripcionService inscripcionService;
        public InscripcionController(IInscripcionService inscripcionService){
            this.inscripcionService = inscripcionService;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Inscripcion inscripcion){
            return Ok(
                inscripcionService.Create(inscripcion)
            );
        }

    }
}