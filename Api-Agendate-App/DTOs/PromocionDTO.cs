namespace Api_Agendate_App.Models
{
    public class PromocionDTO
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public int intervalo { get; set; }
     
    }
}
