
using Logic.Data;
using Logic.Entities;

using Repositorio.Interfases;

namespace Repositorio.EntidadesDeRepositorio
{
    public class EmpresaRepositorio : Repositorio<Empresa>, IEmpresa
    {
        public readonly DataContext _db;
        public EmpresaRepositorio(DataContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Empresa> Actualizar(Empresa entidad)
        {
            var Encontre = _db.Empresas.FirstOrDefault(Emp => Emp.Id == entidad.Id);
            if (Encontre != null)
            {
                ActurlizarAtributos(ref Encontre, entidad);
                await Modificar(Encontre);
            }
            return entidad;
        }

        private void ActurlizarAtributos(ref Empresa encontre, Empresa entidad)
        {
            try
            {
                if (entidad.Nombre != encontre.Nombre)
                    encontre.Nombre = entidad.Nombre;
                if (entidad.Apellido != encontre.Apellido)
                    encontre.Apellido = entidad.Apellido;
                if (entidad.Rubro != encontre.Rubro)
                    encontre.Rubro = entidad.Rubro;
                if (entidad.Celular != encontre.Celular)
                    encontre.Celular = entidad.Celular;
                if (entidad.Correo != encontre.Correo)
                    encontre.Correo = entidad.Correo;
                if (entidad.Direccion != encontre.Direccion)
                    encontre.Direccion = entidad.Direccion;
                if (entidad.Ciudad != encontre.Ciudad)
                    encontre.Ciudad = entidad.Ciudad;
                if (entidad.Latitude != encontre.Latitude)
                    encontre.Latitude = entidad.Latitude;
                if (entidad.Longitude != encontre.Longitude)
                    encontre.Longitude = entidad.Longitude;
                if (entidad.Direccion != encontre.Direccion)
                    encontre.Descripcion = entidad.Descripcion;
                if(entidad.Logo != encontre.Logo)
                    encontre.Logo = entidad.Logo;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
