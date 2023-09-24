
using Logic.Data;
using Logic.Entities;

using Repositorio.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.EntidadesDeRepositorio
{
    public class EmpresaRepositorio : Repositorio<Empresa>, IEmpresa
    {
        public readonly DataContext _db;
        public EmpresaRepositorio(DataContext db) : base(db)
        {
            _db= db;
        }

        public async Task<Empresa> Actualizar(Empresa entidad)
        {
            var Encontre = _db.Empresas.FirstOrDefault(Emp => Emp.Id == entidad.Id);
            if (Encontre!=null)
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
                encontre.Nombre = entidad.Nombre;
                encontre.Apellido= entidad.Apellido;
                encontre.NombreUsuario = entidad.NombreUsuario;
                encontre.Rubro= entidad.Rubro;
                encontre.Celular= entidad.Celular;
                encontre.Contrasenia= entidad.Contrasenia;
                encontre.Correo= entidad.Correo;
                encontre.Direccion= entidad.Direccion;
                encontre.Ciudad= entidad.Ciudad;
                encontre.Latitude= entidad.Latitude;
                encontre.Longitude= entidad.Longitude;
                encontre.Descripcion= entidad.Descripcion;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
