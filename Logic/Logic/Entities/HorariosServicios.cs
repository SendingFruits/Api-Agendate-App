using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class HorariosServicios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }

        public int HorariosID { get; set; }

        public int ServiciosID { get; set; }

        public virtual Servicios Servicios { get; set; }

        public virtual Horarios Horarios { get; set; }
    }
}
