using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Parcial.Domain;
using Parcial.Service;

namespace Parcial.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TorneoController:ControllerBase
    {
        private ITorneoService torneoService;

        public TorneoController(ITorneoService torneoService){
            this.torneoService = torneoService;
        }

        [HttpGet]
        public ActionResult Get(){
            return Ok(
                torneoService.FindAll()
            );
        }
        
        [HttpPost]
        public ActionResult Post([FromBody]Torneo torneo){
            return Ok(
                torneoService.Create(torneo)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody]Torneo torneo){
            return Ok(
                torneoService.Update(torneo)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id){
            return Ok(
                torneoService.Delete(id)
            );
        }


    }
}