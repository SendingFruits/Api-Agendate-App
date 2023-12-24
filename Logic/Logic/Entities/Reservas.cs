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
        
        [Required]
        public DateTime FechaRealiada { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public int ServicioID { get; set; }

        [Required]
        public int ClienteID { get; set; }

        [Required]
        public virtual Clientes Cliente { get; set; }

        [Required]
        public virtual Servicios Servicio { get; set; }

    }
}
