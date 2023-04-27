using Api_Agendate_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_Agendate_App.Controllers
{

    [ApiController]
    [Route("api/Promociones")]
    public class PromocionesController : ControllerBase
    {
        private static List<MPromocion> promociones = new List<MPromocion>()
        {
            new MPromocion
            {
                id = 1,
                titulo = "Nueva promocion",
                descripcion = "Una descripcion clara",
                fechaInicio = DateTime.Now,
                fechaFin = DateTime.Now.AddDays(5),
                servicioAsociado = new MServicios()
            },
            new MPromocion
            {
                id = 2,
                titulo = "Nueva Segunda promocion",
                descripcion = "Otra descripcion clara",
                fechaInicio = DateTime.Now,
                fechaFin = DateTime.Now.AddDays(3),
                servicioAsociado = new MServicios()
            }
        };

        #region GETs...
        [HttpGet]
        public async Task<ActionResult<List<MPromocion>>> GetAllPromociones()
        {
            return Ok(promociones);
        }

        [HttpGet("{idPromocion}")]
        public async Task<ActionResult<List<MPromocion>>> GetPromocion(int p_id)
        {
            var promocion = promociones.FirstOrDefault(e => e.id == p_id);
            if (promocion == null)
                return BadRequest("No se encontro la empresa.");
            return Ok(promocion);
        }
        #endregion

        #region POSTs...
        [HttpPost]
        public async Task<ActionResult<List<MPromocion>>> AddPromocion(MPromocion p_promocion)
        {
            promociones.Add(p_promocion);
            return Ok(promociones);
        }
        #endregion

        #region UPDATEs...
        [HttpPut]

        public async Task<ActionResult<List<MPromocion>>> UpdatePromocion(MPromocion p_promocion)
        {
            var promocion = promociones.FirstOrDefault(x => x.id == p_promocion.id);
            if (promocion == null)
                return BadRequest("No se encontró la promocion a modificar.");


            promocion.titulo = p_promocion.titulo;
            promocion.fechaInicio = p_promocion.fechaInicio;
            promocion.fechaFin = p_promocion.fechaFin;

            return Ok(promocion);
        }

        #endregion

        #region DELETEs...

        [HttpDelete("{id}")]

        public async Task<ActionResult<MPromocion>> DeletePromocion(int p_id)
        {
            var promocion = promociones.FirstOrDefault(e => e.id == p_id);
            if (promocion == null)
                return BadRequest("No se encontro la agenda.");

            promociones.Remove(promocion);
            return Ok(promociones);
        }
        #endregion
    }


}
