using Api_Agendate_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_Agendate_App.Controllers
{
    [ApiController]
    [Route("api/Servicios")]
    public class ServiciosController: ControllerBase
    {
        
        private List<MServicios> mServicios = new List<MServicios>
        {
            new MServicios
            {
                Nombre = "Peluquería",
                Tipo = "peluquería",
                Descripcion= "Una Descripción muy espectacular",
                FechaInicio= DateTime.Now,
                FechaFin = DateTime.UtcNow

                
            }
        };


          [HttpGet]
        public async Task<ActionResult<List<MServicios>>> getServicios()
        {
            return Ok(mServicios);
        }

        [HttpPost]
        public async Task<ActionResult<List<MServicios>>> AddServicio(MServicios unServicio)
        {
            mServicios.Add(unServicio);
            return Ok(mServicios);
        }

        [HttpPost]
        public async Task<ActionResult<List<MServicios>>> RemoveServicio(MServicios unServicio)
        {
            mServicios.Remove(unServicio);
            return Ok(mServicios);
        }
    
      


    }
}
