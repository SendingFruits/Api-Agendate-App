using System.Linq.Expressions;

namespace Repositorio.IRepositorio
{
    public interface IRepositorio<T> where T : class
    {
        Task Crear(T entidad);

        Task<IEnumerable<T>> ObtenerTodos(Expression<Func<T, bool>>? filto = null);

        Task<T> Obtener(Expression<Func<T, bool>>? filto = null, bool tracker = true);

        Task Remover(T entidad);

        Task Grabar();

    }
}