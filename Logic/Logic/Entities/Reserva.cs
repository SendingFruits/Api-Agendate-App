using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Cliente cliente { get; set; }
        [Required]
        public Servicio servicio { get; set; }
        [Required]
        public DateTime horarioReserva { get; set; }

        [Required]
        public bool Estado { get; set; }


    }
}
