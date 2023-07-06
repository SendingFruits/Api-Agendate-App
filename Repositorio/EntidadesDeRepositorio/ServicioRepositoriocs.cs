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
        public ServicioRepositorios(DataContext db) : base(db)
        {

        }

        public Task<Servicio> Actualizar(Servicio entidad)
        {
            throw new NotImplementedException();
        }
    }
}
