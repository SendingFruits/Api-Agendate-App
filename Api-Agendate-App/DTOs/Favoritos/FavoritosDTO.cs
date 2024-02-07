using Logic.Entities;
using System.ComponentModel.DataAnnotations;

namespace Api_Agendate_App.DTOs.Favoritos
{
    public class FavoritosDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdServicio { get; set; }
        public bool recibirNotificaciones { get; set; } = true;

        public string RazonSocial { get; set; }

        public string DescripcionEmpresa { get; set; }

        public string DireccionEmpresa { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public string NombreServicio { get; set; }

        public string TipoServicio { get; set; }

        public bool ServicioActivo { get; set; } = false;
    }
}
