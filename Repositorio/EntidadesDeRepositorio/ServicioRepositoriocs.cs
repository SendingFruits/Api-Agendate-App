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
    public class ServicioRepositorios : Repositorio<Servicios>, IServicios
    {
        public readonly DataContext _db;
        public ServicioRepositorios(DataContext db) : base(db)
        {
            _db= db;
        }

        public async Task<Servicios> Actualizar(Servicios entidad)
        {
            await Modificar(entidad);
            return entidad;
        }
    }
}
