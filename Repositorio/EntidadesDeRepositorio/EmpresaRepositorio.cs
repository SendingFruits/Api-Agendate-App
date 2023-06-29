using Api_Agendate_App.Models;
using Logic.Data;
using Logic.Entities;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.EntidadesDeRepositorio
{
    public class EmpresaRepositorio : Repositorio<EmpresaRepositorio>, IEmpresa
    {
        public readonly DataContext _db;
        public EmpresaRepositorio(DataContext db) : base(db)
        {
            _db= db;
        }

        


        public async Task<EmpresaDTO> Actualizar(EmpresaDTO entidad)
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
            _db.Empresas.Add(e);
            await _db.SaveChangesAsync();

            return entidad;
        }
    }
}
