using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Logic.Entities
{
    [Index(nameof(Documento), IsUnique = true)]
    public class Cliente : Usuario
    {
        [Required(ErrorMessage = "El campo No puede ser nulo o vacio")]
        public string Documento { get; set; }
        //public byte[]? Foto { get; set; }
    }
}