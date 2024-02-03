using Api_Agendate_App.DTOs.Usuarios;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Api_Agendate_App.DTOs.Empresas
{
    public class EmpresaDTO : UsuarioDTO
    {
        public string RutDocumento { get; set; }

        public string RazonSocial { get; set; }

        public string NombrePropietario { get; set; }

        public string Rubro { get; set; }

        public string Direccion { get; set; }

        public string Ciudad { get; set; }

        public string? Logo { get; set; }

        public string Descripcion { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }
    }

    public class EmpresaBuscadaDTO : UsuarioDTO
    {
        public string RazonSocial { get; set; }

        public string Descripcion { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }
    }
}
