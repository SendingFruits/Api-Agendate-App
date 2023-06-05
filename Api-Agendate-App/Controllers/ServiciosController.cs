using Api_Agendate_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_Agendate_App.Controllers
{
    [ApiController]
    [Route("api/Servicios")]
    public class ServiciosController: ControllerBase
    {
        
        private List<ServicioDTO> mServicios = new List<ServicioDTO>
        {
            new ServicioDTO
            {
                Nombre = "Peluquería",
                Tipo = "peluquería",
                Descripcion= "Una Descripción muy espectacular",
                FechaInicio= DateTime.Now,
                FechaFin = DateTime.UtcNow

                
            }
        };


          [HttpGet]
        public async Task<ActionResult<List<ServicioDTO>>> getServicios()
        {
            return Ok(mServicios);
        }

        [HttpPost]
        public async Task<ActionResult<List<ServicioDTO>>> AddServicio(ServicioDTO unServicio)
        {
            mServicios.Add(unServicio);
            return Ok(mServicios);
        }

        [HttpPost]
        public async Task<ActionResult<List<ServicioDTO>>> RemoveServicio(ServicioDTO unServicio)
        {
            mServicios.Remove(unServicio);
            return Ok(mServicios);
        }
    
      


    }
}
