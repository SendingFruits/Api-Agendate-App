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
    public class HorariosRepositorio : Repositorio<Horarios>, IHorarios
    {
        public readonly DataContext _db;

        public HorariosRepositorio(DataContext db) : base(db)
        {
            _db = db;
        }
    }
}
