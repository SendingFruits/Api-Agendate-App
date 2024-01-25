
using Logic.Data;
using Logic.Entities;

using Repositorio.Interfases;

namespace Repositorio.EntidadesDeRepositorio
{
    public class FavoritosRepositorio : Repositorio<Favoritos>, IFavoritos
    {
        public readonly DataContext _db;
        public FavoritosRepositorio(DataContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Favoritos> Actualizar(Favoritos entidad)
        {
            var Encontre = _db.Favoritos.FirstOrDefault(f => f.Id == f.Id);
            if (Encontre != null)
            {
                await Modificar(Encontre);
            }
            return entidad;
        }


    }
}
