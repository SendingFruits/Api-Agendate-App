using Logic.Entities;

namespace Api_Agendate_App.DTOs.Promociones
{
    public class PromocionDTO
    {
        public int Id { get; set; }

        public DateTime? UltimoEnvio { get; set; }

        public string CuerpoMensaje { get; set; }

        public string AsuntoMensaje { get; set; }

        public int EmpresaId { get; set; }

    }

    public class PromocionDTOActualizar
    {
        public int Id { get; set; }

        public string CuerpoMensaje { get; set; }

        public string AsuntoMensaje { get; set; }

    }
}
