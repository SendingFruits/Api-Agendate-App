using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Logic.Data;
using Repositorio.IRepositorio;

namespace Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly DataContext _Db;
        internal DbSet<T> dbSet;

        public Repositorio(DataContext db)
        {
            _Db = db;
            this.dbSet = _Db.Set<T>();
        }

        public async Task Crear(T entidad)
        {
            await dbSet.AddAsync(entidad);
            await Grabar();
        }

        public async Task Grabar()
        {
            await _Db.SaveChangesAsync();
        }

        public async Task<T> Obtener(Expression<Func<T, bool>>? filto = null, bool tracker = true)
        {
            IQueryable<T> query = dbSet;
            //Si no tiene filtro
            if (!tracker)
            {
                query = query.AsNoTracking();
            }
            //Se aplica el filtro 
            if (filto != null)
            {
                query = query.Where(filto);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> ObtenerTodos(Expression<Func<T, bool>>? filto = null)
        {
            IQueryable<T> query = dbSet;
            if (filto != null)
            {
                query = query.Where(filto);
            }
            return await query.ToListAsync();
        }

        public async Task Remover(T entidad)
        {
            dbSet.Remove(entidad);
            await Grabar();
        }
    }
}