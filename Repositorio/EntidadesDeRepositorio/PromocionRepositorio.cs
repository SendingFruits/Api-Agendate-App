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
    internal class PromocionRepositorio : Repositorio<Promociones>, IPromocion
    {
        public readonly DataContext _db;
        public PromocionRepositorio(DataContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Promociones> Actualizar(Promociones entidad)
        {
            var Encontre = _db.Promociones.FirstOrDefault(Pro =>Pro.Id == entidad.Id);
            if (Encontre != null)
            {
                await Modificar(Encontre);
            }
            return entidad;
        }

    }
}
