using Api_Agendate_App.Models;

namespace Api_Agendate_App.DTOs
{
    public class CrearEmpresaDTO:UsuarioDTO
    {
        public string RutDocumento { get; set; }

        public bool Bandera { get; set; }


    }
}
