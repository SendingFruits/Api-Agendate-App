using Logic.Data;
using Logic.Entities;
using Repositorio.IRepositorio;

namespace Repositorio
{
    public class ClienteRepositorio : Repositorio<Clientes>, ICliente
    {
        private readonly DataContext _db;
        public ClienteRepositorio(DataContext db) : base(db)
        {
            _db = db;
        }

    }
}