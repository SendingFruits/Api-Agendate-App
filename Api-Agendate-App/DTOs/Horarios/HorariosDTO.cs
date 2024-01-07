namespace Api_Agendate_App.DTOs.Horarios
{
    public class HorariosDTO
    {
        DateTime FechaHora { get; set; }
        bool Disponible { get; set; }

        public HorariosDTO (DateTime fechaHora, bool disponible)
        {
            FechaHora = fechaHora;
            Disponible = disponible;
        }
    }
}
