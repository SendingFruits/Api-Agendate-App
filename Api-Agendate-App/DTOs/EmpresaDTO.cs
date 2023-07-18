using System.Numerics;

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

        public decimal Latitud { get; set; }

        public decimal Longitud { get; set; }

        //public byte[]? Logo { get; set; }

        public string Descripcion { get; set; }
    }
}
