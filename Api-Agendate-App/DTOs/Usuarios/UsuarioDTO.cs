using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api_Agendate_App.DTOs
{
    public class UsuarioDTO
    {
        [JsonIgnore]
        [Required(ErrorMessage = "El campo No puede ser nulo o vacio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo No puede ser nulo o vacio")]
        [StringLength(100, ErrorMessage = "Sólo se aceptan 100 caracteres")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Se Requiere un Nombre")]
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo No puede ser nulo o vacio")]
        [StringLength(100, ErrorMessage = "Sólo se aceptan 100 caracteres")]
        public string Contrasenia { get; set; }

        [Required(ErrorMessage = "Debe colocar un Celular ")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "El campo No puede ser nulo o vacio")]
        public string Correo { get; set; }
        
        public string TipoUsuario { get; set; }
    }

    public class UsuarioPassDTO
    {
        [Required(ErrorMessage = "El campo No puede ser nulo o vacio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo No puede ser nulo o vacio")]
        [StringLength(100, ErrorMessage = "Sólo se aceptan 100 caracteres")]
        public string PassVieja { get; set; }

        [Required(ErrorMessage = "El campo No puede ser nulo o vacio")]
        [StringLength(100, ErrorMessage = "Sólo se aceptan 100 caracteres")]
        public string PassNueva { get; set; }
    }
}
