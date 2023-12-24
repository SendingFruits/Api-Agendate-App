
using Logic.Data;
using Logic.Entities;

using Repositorio.Interfases;

namespace Repositorio.EntidadesDeRepositorio
{
    public class EmpresaRepositorio : Repositorio<Empresas>, IEmpresa
    {
        public readonly DataContext _db;
        public EmpresaRepositorio(DataContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Empresas> Actualizar(Empresas entidad)
        {
            var Encontre = _db.Empresas.FirstOrDefault(Emp => Emp.Id == entidad.Id);
            if (Encontre != null)
            {
                await Modificar(Encontre);
            }
            return entidad;
        }


    }
}
