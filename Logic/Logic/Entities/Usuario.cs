﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Logic.Entities
{
    [Index(nameof(NombreUsuario), IsUnique = true)]
    public class Usuario
    {
        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "El campo No puede ser nulo o vacio")]
        [StringLength(100, ErrorMessage = "Sólo se aceptan 100 caracteres")]
        public string NombreUsuario { get; set; }

        [Column(Order = 2)]
        [Required(ErrorMessage = "Se Requiere un Nombre")]
        public string Nombre { get; set; }

        [Column(Order = 3)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo No puede ser nulo o vacio")]
        [StringLength(100, ErrorMessage = "Sólo se aceptan 100 caracteres")]
        public string Contrasenia { get; set; }

        [Required(ErrorMessage = "Debe colocar un Celular ")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "El camnpo No puede ser nulo o vacio")]
        public string Correo { get; set; }

    }
}
