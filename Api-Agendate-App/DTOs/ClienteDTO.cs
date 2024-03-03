using System.ComponentModel.DataAnnotations;

namespace Api_Agendate_App.DTOs
{
    public class ClienteDTO : UsuarioDTO
    {
        public string documento { get; set; }
    }

    public class ClienteDTOBasico
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

        public string Documento { get; set; }

        public string Foto { get; set; }

        public bool tieneNotificaciones { get; set; }

    }
}
