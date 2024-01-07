namespace Api_Agendate_App.DTOs.Horarios
{
    public class HorariosDTO
    {
        public DateTime FechaHora { get; set; }
        public bool Disponible { get; set; }

        public HorariosDTO (DateTime fechaHora, bool disponible)
        {
            FechaHora = fechaHora;
            Disponible = disponible;
        }
    }
}
