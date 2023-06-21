using Api_Agendate_App.Services;
using Api_Agendate_App.Utilidades;
using Logic.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api_Agendate_App.Controllers
{

    [ApiController]
    [Route("api/Empresas")]
    public class EmpresasController : ControllerBase
    {
       
      

      
        private readonly EmpresasService _empresasService;
        public EmpresasController(EmpresasService empresasService)
        {
            _empresasService = empresasService;
        }

        #region POSTs...
        [HttpPost]
        public async Task<ActionResult<Empresa>> AddEmpresas(Empresa p_Empresa)
        {
            APIRespuestas respuesta =  _empresasService.Create(p_Empresa);
            if (respuesta.codigo == 0)
            {
                return Ok();
            }
            else
            {
                respuesta.ObtenerMensaje(respuesta.codigo);
                return BadRequest(respuesta.mensaje);
            }
        }
        #endregion
    }
}
