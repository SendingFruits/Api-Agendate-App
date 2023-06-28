using Logic.Data;
using Logic.Entities;
using Repositorio.IRepositorio;

namespace Repositorio.EntidadesDeRepositorio
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuario
    {
        private readonly DataContext _db;

        public UsuarioRepositorio(DataContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Usuario> Actualizar(Usuario entidad)
        {
            entidad.Celular = entidad.Celular;
            _db.Usuarios.Add(entidad);
            await _db.SaveChangesAsync();
            return entidad;
        }
    }
}