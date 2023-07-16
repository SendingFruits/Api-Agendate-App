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
    public class ServicioRepositorios : Repositorio<Servicio>, IServicios
    {
        public readonly DataContext _db;
        public ServicioRepositorios(DataContext db) : base(db)
        {
            _db= db;
        }

        public async Task<Servicio> Actualizar(Servicio entidad)
        {
            var Buscar = _db.Servicios.FirstOrDefault(s => s.Id == entidad.Id);
            if (Buscar != null)
            {
                Servicio s = new Servicio
                {
                    Id = entidad.Id,
                    Nombre = entidad.Nombre,
                    Costo= entidad.Costo,
                    Cupos= entidad.Cupos,
                    Descripcion= entidad.Descripcion,
                    FechaInicio= entidad.FechaInicio,
                    FechaFin= entidad.FechaFin,
                    Frecuencia= entidad.Frecuencia,
                    Tipo= entidad.Tipo,
                    empresa= entidad.empresa
                };
                _db.Entry(s).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _db.SaveChangesAsync();
            }

            return entidad;
        }
    }
}
