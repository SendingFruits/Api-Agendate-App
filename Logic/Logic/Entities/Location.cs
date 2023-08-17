using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public float latitude { get; set; }
        public float latitudeDelta { get; set; }
        public float longitude { get; set; }
        public float longitudeDelta { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
