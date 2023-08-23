
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
            var Encontre = _db.Empresas.FirstOrDefault(Emp => Emp.NombreUsuario == entidad.NombreUsuario);
            if (Encontre!=null)
            {   
                Empresa e = new Empresa
                    {
                        Nombre = entidad.Nombre,
                        //Logo= entidad.Logo,
                        Celular= entidad.Celular,
                        Contrasenia= entidad.Contrasenia,
                        NombreUsuario= entidad.NombreUsuario,
                        RutDocumento = entidad.RutDocumento,
                        RazonSocial = entidad.RazonSocial,
                        Descripcion = entidad.Descripcion,
                        Apellido= entidad.Apellido,
                        Ciudad= entidad.Ciudad,
                        Correo= entidad.Correo,
                        Direccion = entidad.Direccion,
                        NombrePropietario= entidad.NombrePropietario,
                        Rubro= entidad.Rubro

                    };
                      _db.Entry(e).State= Microsoft.EntityFrameworkCore.EntityState.Modified;
                     await _db.SaveChangesAsync();



            }
           
          

            return entidad;
        }
    }
}
