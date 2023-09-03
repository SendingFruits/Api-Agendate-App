using Api_Agendate_App.DTOs;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Api_Agendate_App.Models
{
    public class EmpresaDTO : UsuarioDTO
    {
        public string RutDocumento { get; set; }

        public string RazonSocial { get; set; }

        public string NombrePropietario { get; set; }

        public string Rubro { get; set; }

        public string Calle { get; set; }

        public string NumeroPuerta { get; set; }

        public string Ciudad { get; set; }

        //public byte[]? Logo { get; set; }

        public string Descripcion { get; set; }

        public bool Bandera { get; set; }
    }
}
