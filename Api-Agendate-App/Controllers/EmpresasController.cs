using Api_Agendate_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_Agendate_App.Controllers
{

    [ApiController]
    [Route("api/Empresas")]
    public class EmpresasController : ControllerBase
    {
        private static List<MEmpresas> empresas = new List<MEmpresas>()
        {
            new MEmpresas {
                documentoIdentificatorio = "123456789012", //RUC
                razonSocial = "Una Empresa con RUT",
                correo = "UnaEmpresaConRut@gmail.com",
                nombrePropietario = "Un Empresario JR",
                direccion = "18 de Julio 1254",
                rubro = "Peluqueria",
                ubicacionEnCoordenadas = "12;44;22;33",
                pais = "Uruguay"
            },

            new MEmpresas {
                documentoIdentificatorio = "51217200", //Cedula
                razonSocial = "Una Empresa con Cedula !",
                correo = "UnaEmpresaConCedula@gmail.com",
                nombrePropietario = "Un Empresario normal",
                direccion = "8 de Octubre 1333",
                rubro = "Barberia",
                ubicacionEnCoordenadas = "44;22;13;66",
                pais = "Uruguay"
            }
        };

        #region GETs...
        [HttpGet]
        public async Task<ActionResult<List<MEmpresas>>> GetAllEmpresas()
        {
            return Ok(empresas);
        }

        [HttpGet ("{documentoIdentificatorio}")]
        public async Task<ActionResult<List<MEmpresas>>> GetEmpresas(string documentoIdentificatorio)
        {
            var empresa = empresas.FirstOrDefault(e => e.documentoIdentificatorio == documentoIdentificatorio.Trim());
            if (empresa == null)
                return BadRequest("No se encontro la empresa.");
            return Ok(empresa);
        }
        #endregion

        #region POSTs...
        [HttpPost]
        public async Task<ActionResult<List<MEmpresas>>> AddEmpresas(MEmpresas p_Empresa)
        {
            empresas.Add(p_Empresa);
            return Ok(empresas);
        }
        #endregion

        #region UPDATEs...
        [HttpPut]

        public async Task<ActionResult<List<MEmpresas>>> UpdateEmpresas(MEmpresas p_Empresa)
        {
            var empresa = empresas.FirstOrDefault(x => x.documentoIdentificatorio == p_Empresa.documentoIdentificatorio);
            if (empresa == null)
                return BadRequest("No se encontró la empresa a modificar.");


            empresa.razonSocial = p_Empresa.razonSocial;
            empresa.correo = p_Empresa.correo;
            empresa.nombrePropietario = p_Empresa.nombrePropietario;
            empresa.direccion = p_Empresa.direccion;
            empresa.rubro = p_Empresa.rubro;
            empresa.ubicacionEnCoordenadas = p_Empresa.ubicacionEnCoordenadas;
            empresa.pais = p_Empresa.pais;

            return Ok(empresas);
        }

        #endregion

        #region DELETEs...

        [HttpDelete("{documentoIdentificatorio}")]

        public async Task<ActionResult<MEmpresas>> DeleteEmpresa(string documentoIdentificatorio)
        {
            var empresa = empresas.FirstOrDefault(e => e.documentoIdentificatorio == documentoIdentificatorio.Trim());
            if (empresa == null)
                return BadRequest("No se encontro la empresa.");

            empresas.Remove(empresa);
            return Ok(empresas);
        }
        #endregion
    }
}
