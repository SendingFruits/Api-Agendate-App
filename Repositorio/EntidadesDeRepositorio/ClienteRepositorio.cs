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

        public async Task<Cliente> Actualizar(Cliente p_entidad)
        {
            var clienteBD = _db.Clientes.FirstOrDefault(s=> s.NombreUsuario== p_entidad.NombreUsuario);
            if (clienteBD != null)
            {
                ActualizarAtributos(ref clienteBD, p_entidad);
                await Modificar(clienteBD);
            }
           
            return p_entidad;
        }

        private void ActualizarAtributos (ref Cliente entidadBase, Cliente entidadModificada)
        {
            try
            {
                entidadBase.Nombre = entidadModificada.Nombre;
                entidadBase.Apellido = entidadModificada.Apellido;
                entidadBase.Correo = entidadModificada.Correo;
                entidadBase.Celular = entidadModificada.Celular;
                entidadBase.Documento = entidadModificada.Documento;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}