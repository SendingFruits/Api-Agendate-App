namespace Api_Agendate_App.DTOs.Horarios
{
    public class HorariosDTO
    {
        public DateTime FechaHora { get; set; }
        public bool Disponible { get; set; }

        public HorariosDTO(DateTime fechaHora, bool disponible)
        {
            FechaHora = fechaHora;
            Disponible = disponible;
        }
    }
    public class HorarioDia
    {
        public decimal? HoraInicio { get; set; }
        public decimal? HoraFin { get; set; }
    }

    public class HorarioSemana
    {
        public HorarioDia Lunes { get; set; }
        public HorarioDia Martes { get; set; }
        public HorarioDia Miercoles { get; set; }
        public HorarioDia Jueves { get; set; }
        public HorarioDia Viernes { get; set; }
        public HorarioDia Sabado { get; set; }
        public HorarioDia Domingo { get; set; }
    }
}
