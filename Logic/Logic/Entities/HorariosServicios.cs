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
        int HorarioServicioID {  get; set; }

        int HorarioID { get; set; }

        int ServiciosID { get; set; }

        public virtual Servicios Servicios { get; set; }

        public virtual Horarios Horarios { get; set; }
    }
}
