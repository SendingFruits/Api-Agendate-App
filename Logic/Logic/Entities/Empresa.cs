using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Logic.Entities
{
    [Index(nameof(RutDocumento), IsUnique = true)]
    public class Empresa : Usuario
    {
        [Required(ErrorMessage = "El documento es obligatorio.")]
        public string RutDocumento { get; set; }
        
        public string RazonSocial { get; set; }

        public string NombrePropietario { get; set; }

        public string Rubro { get; set; }

        public string Calle { get; set; }

        public string NumeroPuerta { get; set; }

        public string Ciudad { get; set; }
        public string Descripcion { get; set; }

    }
}
