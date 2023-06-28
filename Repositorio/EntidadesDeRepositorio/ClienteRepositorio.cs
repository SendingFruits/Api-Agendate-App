using Logic.Data;
using Repositorio.IRepositorio;

namespace Repositorio
{
    public class ClienteRepositorio : Repositorio<ClienteRepositorio>, IClienteRepositorio
    {
        private readonly DataContext _db;
        public ClienteRepositorio(DataContext db) : base(db)
        {
            _db = db;
        }

        public async Task<ClienteRepositorio> Actualizar(ClienteRepositorio entidad)
        {
            throw new NotImplementedException();
            /*_db.clientes.Add(entidad);
            await _db.SaveChangesAsync();
            return entidad;*/
        }
    }
}