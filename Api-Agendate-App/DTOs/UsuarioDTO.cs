using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api_Agendate_App.Models
{
    public class UsuarioDTO
    { 
        [Required(ErrorMessage = "El campo No puede ser nulo o vacio")]
        [StringLength(100, ErrorMessage = "Sólo se aceptan 100 caracteres")]
        public string NombreUsuario { get; set; }

       
        [Required(ErrorMessage = "El campo No puede ser nulo o vacio")]
        [StringLength(100, ErrorMessage = "Sólo se aceptan 100 caracteres")]
        public string Contrasenia { get; set; }

        [Required(ErrorMessage = "Debe colocar un Celular ")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "El camnpo No puede ser nulo o vacio")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Se Requiere un Nombre")]
        public string Nombre { get; set; }

        public string Apellido { get; set; }
    }
}
