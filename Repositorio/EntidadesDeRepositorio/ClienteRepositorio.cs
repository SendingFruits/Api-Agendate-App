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

        public async Task<Clientes> Actualizar(Clientes entidad)
        {
            var Encontre = _db.Clientes.FirstOrDefault(cli => cli.Id == entidad.Id);
            if (Encontre != null)
            {
                await Modificar(Encontre);
            }
            return entidad;
        }
    }
}