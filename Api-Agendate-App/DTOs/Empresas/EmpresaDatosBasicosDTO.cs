using System.ComponentModel.DataAnnotations;

namespace Api_Agendate_App.DTOs.Empresas
{
    public class EmpresaDatosBasicosDTO
    {
        public int Id { get; set; }

        public string RutDocumento { get; set; }

        public string RazonSocial { get; set; }

        public string NombrePropietario { get; set; }

        public string Rubro { get; set; }

        public string Direccion { get; set; }

        public string Ciudad { get; set; }

        public string Descripcion { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

    }
}
