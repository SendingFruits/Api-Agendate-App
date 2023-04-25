using Api_Agendate_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_Agendate_App.Controllers
{

    [ApiController]
    [Route("api/Empresas")]
    public class AgendasController : ControllerBase
    {
        private static List<MAgenda> agendas = new List<MAgenda>()
        {
            new MAgenda
            {
                id = 1,
                nombre = "Nueva Agenda",
                empresaCreadora = new MEmpresas(),
                fechaCreacion = DateTime.Now,
                horaInicio = 9,
                horaFin = 21,
                activa = true
            },
            new MAgenda
            {
                id = 2,
                nombre = "Nueva Agenda 2 ",
                empresaCreadora = new MEmpresas(),
                fechaCreacion = DateTime.Now.AddDays(2),
                horaInicio = 10,
                horaFin = 15,
                activa = false
            }
        };

        #region GETs...
        [HttpGet]
        public async Task<ActionResult<List<MAgenda>>> GetAllAgendas()
        {
            return Ok(agendas);
        }

        [HttpGet ("{idAgenda}")]
        public async Task<ActionResult<List<MAgenda>>> GetAgenda(int p_id)
        {
            var agenda = agendas.FirstOrDefault(e => e.id == p_id);
            if (agenda == null)
                return BadRequest("No se encontro la empresa.");
            return Ok(agenda);
        }
        #endregion

        #region POSTs...
        [HttpPost]
        public async Task<ActionResult<List<MEmpresas>>> AddAgenda(MAgenda p_agenda)
        {
            agendas.Add(p_agenda);
            return Ok(agendas);
        }
        #endregion

        #region UPDATEs...
        [HttpPut]

        public async Task<ActionResult<List<MAgenda>>> UpdateAgenda(MAgenda p_agenda)
        {
            var agenda = agendas.FirstOrDefault(x => x.id == p_agenda.id);
            if (agenda == null)
                return BadRequest("No se encontró la agenda a modificar.");


            agenda.nombre = p_agenda.nombre;
            agenda.horaInicio = p_agenda.horaInicio;
            agenda.horaFin = p_agenda.horaFin;
            agenda.activa = p_agenda.activa;

            return Ok(agenda);
        }

        #endregion

        #region DELETEs...

        [HttpDelete("{id}")]

        public async Task<ActionResult<MEmpresas>> DeleteAgenda(int p_id)
        {
            var agenda = agendas.FirstOrDefault(e => e.id == p_id);
            if (agenda == null)
                return BadRequest("No se encontro la agenda.");

            agendas.Remove(agenda);
            return Ok(agendas);
        }
        #endregion
    }
}
