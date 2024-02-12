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
        public DateTime FechaHoraTurno { get; set; }

        public string Estado { get; set; }

        public int ClienteId { get; set; }

        public virtual Clientes Cliente { get; set; }

        public int ServicioId { get; set; }

        public virtual Servicios Servicio { get; set; }
    }
}