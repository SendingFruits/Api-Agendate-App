using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class Favoritos
    {
        [Required]

        public int Clienteid { get; set; }
        [Required]
        public int ServicioId { get; set; }

        [Required]
        public virtual Clientes Cliente { get; set; }

        [Required]
        public virtual Servicios Servicio { get; set; }


    }
}
