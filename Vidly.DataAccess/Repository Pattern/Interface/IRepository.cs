using System.Linq.Expressions;

namespace Vidly.Repository_Pattern.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? includeProperties = null);
        T Get(Expression<Func<T, bool>> filer, string? includeProperties = null);
        void Add(T entity);
        void Delete(T entity);
        void DeleteAll(IEnumerable<T> entity);

    }
}
