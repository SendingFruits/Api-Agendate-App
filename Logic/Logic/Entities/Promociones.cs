using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public  class Promociones
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime UltimoEnvio { get; set; }

        public string CuerpoMensaje { get; set; }

        public string AsuntoMensaje { get; set; }

        public string Destinatarios { get; set; }

        public int EmpresaId { get; set; }

        public virtual Empresas Empresa { get; set; }
    }
}
