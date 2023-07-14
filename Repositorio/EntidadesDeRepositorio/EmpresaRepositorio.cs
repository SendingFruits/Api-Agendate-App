
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
                Empresa e = new Empresa
                    {
                        Id= entidad.Id,
                        Nombre = entidad.Nombre,
                        Logo= entidad.Logo,
                        Calle= entidad.Calle,
                        Celular= entidad.Celular,
                        Contrasenia= entidad.Contrasenia,
                        NombreUsuario= entidad.NombreUsuario,
                        RutDocumento = entidad.RutDocumento,
                        RazonSocial = entidad.RazonSocial,
                        Descripcion = entidad.Descripcion,
                        Apellido= entidad.Apellido,
                        Ciudad= entidad.Ciudad,
                        Correo= entidad.Correo,
                        Latitud= entidad.Latitud,
                        NumeroPuerta= entidad.NumeroPuerta,
                        Longitud= entidad.Longitud,
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
