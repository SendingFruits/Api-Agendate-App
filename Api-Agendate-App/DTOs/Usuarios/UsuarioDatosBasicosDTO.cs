using System.ComponentModel.DataAnnotations;

namespace Api_Agendate_App.DTOs.Usuarios
{
    public class UsuarioDatosBasicosDTO
    {
        [Required(ErrorMessage = "El campo Id no puede ser nulo o vacio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Se Requiere un Nombre")]
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Debe colocar un Celular ")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "El correo no puede ser nulo o vacio")]
        public string Correo { get; set; }
    }
}
