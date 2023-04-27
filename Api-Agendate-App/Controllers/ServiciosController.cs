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
                id = 1,
                Nombre = "Peluquería",
                Tipo = "peluquería",
                Descripcion= "Una Descripción muy espectacular",
                FechaInicio= DateTime.Now,
                FechaFin = DateTime.UtcNow
            },
            new MServicios
            {
                id = 2,
                Nombre = "Barberia",
                Tipo = "peluquería",
                Descripcion= "Una Descripción Awesome",
                FechaInicio= DateTime.Now,
                FechaFin = DateTime.UtcNow
            }
        };


          [HttpGet]
        public async Task<ActionResult<List<MServicios>>> GetServicios()
        {
            return Ok(mServicios);
        }

        [HttpPost]
        public async Task<ActionResult<List<MServicios>>> AddServicio(MServicios unServicio)
        {
            mServicios.Add(unServicio);
            return Ok(mServicios);
        }

        [HttpDelete("{documentoIdentificatorio}")]
        public async Task<ActionResult<List<MServicios>>> RemoveServicio(int p_id)
        {
            var servicio = mServicios.FirstOrDefault(s => s.id == p_id);
            if (servicio == null)
                return BadRequest("No se encontro el servicio.");

            mServicios.Remove(servicio);
            return Ok(mServicios);
        }

    }
}
