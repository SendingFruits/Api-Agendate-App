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
    public class ReservaRepositorio : Repositorio<Reservas>, IReserva
    {
        private readonly DataContext _db;
        public ReservaRepositorio(DataContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Reservas> Actualizar(Reservas entidad)
        {
            var Encontre = _db.Reservas.FirstOrDefault(r => r.Id == entidad.Id);
            if (Encontre != null)
            {
                await Modificar(Encontre);
            }
            return entidad;
        }
    }
}