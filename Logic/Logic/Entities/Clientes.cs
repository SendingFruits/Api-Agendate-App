using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Logic.Entities
{
    [Index(nameof(Documento), IsUnique = true)]
    public class Clientes : Usuarios
    {
        [Required(ErrorMessage = "El camnpo No puede ser nulo o vacio")]
        public string Documento { get; set; }


        public virtual ICollection<Reservas> Reservas { get; set; }

    }

}
