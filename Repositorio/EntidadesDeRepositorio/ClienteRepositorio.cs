using Logic.Data;
using Logic.Entities;
using Repositorio.IRepositorio;

namespace Repositorio
{
    public class ClienteRepositorio : Repositorio<Cliente>, IClienteRepositorio
    {
        private readonly DataContext _db;
        public ClienteRepositorio(DataContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Cliente> Actualizar(Cliente entidad)
        {
            throw new NotImplementedException();
            _db.Clientes.Add(entidad);
            await _db.SaveChangesAsync();
            return entidad;
        }
    }
}