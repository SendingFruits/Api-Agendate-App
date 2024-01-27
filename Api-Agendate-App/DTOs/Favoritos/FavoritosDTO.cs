using Logic.Entities;

namespace Api_Agendate_App.DTOs.Favoritos
{
    public class FavoritosDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdServicio { get; set; }

        public bool recibirNotificaciones { get; set; } = true;
    }
}
