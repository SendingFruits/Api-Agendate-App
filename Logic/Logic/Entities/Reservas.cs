using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Logic.Entities
{
    public class Reservas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "datetime2(0)")]
        public DateTime FechaRealizada { get; set; }

        [Column(TypeName = "datetime2(0)")]
        public DateTime FechaHoraReserva { get; set; }
        

        public string Estado { get; set; }

        // Clave externa para la relación con Clientes
        public int ClienteId { get; set; }

        // Propiedad de navegación inversa
        public virtual Clientes Cliente { get; set; }

        // Clave externa para la relación con Servicios
        public int ServicioId { get; set; }

        // Propiedad de navegación inversa
        public virtual Servicios Servicio { get; set; }
    }
}