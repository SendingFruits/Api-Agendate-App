using System.Numerics;
using System.Text.Json.Serialization;

namespace Api_Agendate_App.DTOs.Empresas
{
    public class EmpresaMapaDTO
    {
        public int Id { get; set; }

        public string RazonSocial { get; set; }

        public string Rubro { get; set; }

        public string Direccion { get; set; }

        public string Ciudad { get; set; }

        public float Longitude { get; set; }

        public float Latitude { get; set; }

        //public byte[]? Logo { get; set; }

        public string Descripcion { get; set; }
    }
}
