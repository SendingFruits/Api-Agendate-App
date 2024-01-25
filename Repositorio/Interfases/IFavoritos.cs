using Logic.Entities;
using Repositorio.IRepositorio;
namespace Repositorio.Interfases
{
    public interface IFavoritos : IRepositorio<Favoritos>
    {
        public Task<Favoritos> Actualizar(Favoritos entidad);

    }
}
