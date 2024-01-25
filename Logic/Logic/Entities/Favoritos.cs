using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class Favoritos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? ClienteId { get; set; }
        public virtual Clientes? Cliente { get; set; }

        public int? ServicioId { get; set; }

        public virtual Servicios? Servicio { get; set; }

        public bool recibirNotificaciones { get; set ; } = true;

    }
}
