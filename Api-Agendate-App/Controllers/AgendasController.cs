using Api_Agendate_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_Agendate_App.Controllers
{

    [ApiController]
    [Route("api/Empresas")]
    public class AgendasController : ControllerBase
    {
        private static List<AgendaDTO> agendas = new List<AgendaDTO>()
        {
            new AgendaDTO
            {
                id = 1,
                empresaCreadora = new EmpresaDTO(),
                fechaCreacion = DateTime.Now,
                activa = true
            },
            new AgendaDTO
            {
                id = 2,
                empresaCreadora = new EmpresaDTO(),
                fechaCreacion = DateTime.Now.AddDays(2),
                activa = false
            }
        };

        #region GETs...
        [HttpGet]
        public async Task<ActionResult<List<AgendaDTO>>> GetAllAgendas()
        {
            return Ok(agendas);
        }

        [HttpGet ("{idAgenda}")]
        public async Task<ActionResult<List<AgendaDTO>>> GetAgenda(int p_id)
        {
            var agenda = agendas.FirstOrDefault(e => e.id == p_id);
            if (agenda == null)
                return BadRequest("No se encontro la empresa.");
            return Ok(agenda);
        }
        #endregion

        #region POSTs...
        [HttpPost]
        public async Task<ActionResult<List<EmpresaDTO>>> AddAgenda(AgendaDTO p_agenda)
        {
            agendas.Add(p_agenda);
            return Ok(agendas);
        }
        #endregion

        #region UPDATEs...
        [HttpPut]

        public async Task<ActionResult<List<AgendaDTO>>> UpdateAgenda(AgendaDTO p_agenda)
        {
            var agenda = agendas.FirstOrDefault(x => x.id == p_agenda.id);
            if (agenda == null)
                return BadRequest("No se encontró la agenda a modificar.");

            agenda.activa = p_agenda.activa;

            return Ok(agenda);
        }

        #endregion

        #region DELETEs...

        [HttpDelete("{id}")]

        public async Task<ActionResult<EmpresaDTO>> DeleteAgenda(int p_id)
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
