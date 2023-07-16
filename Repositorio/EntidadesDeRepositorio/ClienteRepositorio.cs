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
            var Buscar= _db.Clientes.FirstOrDefault(s=> s.Id== entidad.Id);
            if (Buscar != null)
            {
                Cliente C = new Cliente
                {
                    Id = entidad.Id,
                    Nombre = entidad.Nombre,
                    Foto = entidad.Foto,
                    Apellido = entidad.Apellido,
                    Celular = entidad.Celular,
                    Contrasenia = entidad.Contrasenia,
                    Correo = entidad.Correo,
                    Documento = entidad.Documento,
                    NombreUsuario = entidad.NombreUsuario
                };
                 _db.Entry(C).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                 await _db.SaveChangesAsync();
            }
           
            return entidad;
        }
    }
}