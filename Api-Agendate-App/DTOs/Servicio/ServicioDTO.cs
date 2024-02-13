using System.ComponentModel.DataAnnotations;

namespace Api_Agendate_App.DTOs.Servicio
{
    public class ServicioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string JSONDiasHorariosDisponibilidadServicio { get; set; }

        public int DuracionTurno { get; set; }

        public string TipoServicio { get; set; }

        public decimal? Costo { get; set; }

        public string Descripcion { get; set; }

        public int IdEmpresa { get; set; }

        [Required(ErrorMessage = "El campo No puede ser nulo")]
        public bool Activo { get; set; } = true;


    }
}
