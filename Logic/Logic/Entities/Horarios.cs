using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class Horarios
    {
        [Key]
        public int Id { get; set; }

        public DateTime FechaHora { get; set; }

        public string Categoria { get; set; }
    }
}
