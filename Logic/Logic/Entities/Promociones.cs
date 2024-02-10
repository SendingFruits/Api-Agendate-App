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
        public int Intervalo { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public DateTime FechaFin { get; set; }
        [StringLength(200)]
        public string Descripcion { get; set; }
        [StringLength(200)]
        public string Titulo { get; set;}
        
        public int EmpresaId { get; set; }

        public virtual Empresas? Empresa { get; set; }   

        public int ServicioId { get; set; }

        public virtual Servicios? Servicio { get; set; }


        public List<Clientes>? lClientes { get ; set;}
        public bool Activo { get; set; }
    }
}
