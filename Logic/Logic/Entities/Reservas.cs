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
        public int ClientesID { get; set; }

        [Required]
        public int ServiciosID { get; set; }

        [Required]
        public DateTime FechaHoraReserva { get; set; }

        [Required]
        public string Estado { get; set; }

        public virtual Clientes Clientes { get; set; }

        public virtual Servicios Servicios { get; set; }

    }
}
