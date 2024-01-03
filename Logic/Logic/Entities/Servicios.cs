using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class Servicios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public decimal HoraInicio { get; set; }

        public decimal HoraFin { get; set; }

        public string DiasDefinidosSemana { get; set; }

        public int DuracionTurno { get; set; }

        public string TipoServicio { get; set; }

        public decimal? Costo { get; set; }

        public string Descripcion { get; set; }

        public virtual Empresas Empresa { get; set; }

        public virtual ICollection<Reservas> Reservas { get; set; }

    }
}
