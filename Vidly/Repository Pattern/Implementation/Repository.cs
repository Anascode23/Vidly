using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Vidly.Data;
using Vidly.Repository_Pattern.Interface;

namespace Vidly.Repository_Pattern.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly VidlyDBContext _vidlyDB;
        internal DbSet<T> dbset;

        public Repository(VidlyDBContext vidlyDB)
        {
            _vidlyDB = vidlyDB;
            dbset = _vidlyDB.Set<T>();
            _vidlyDB.Customers.Include(u => u.MembershipType);
            _vidlyDB.Movies.Include(u => u.Genre);
        }
        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        public void DeleteAll(IEnumerable<T> entity)
        {
            dbset.RemoveRange(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbset;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {

                foreach (var property in includeProperties.
                    Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }

            }
            return query.FirstOrDefault();

        }

        public IEnumerable<T> GetAll(string includeProperties = null)
        {
            IQueryable<T> query = dbset;
            if (!string.IsNullOrEmpty(includeProperties))
            {

                foreach (var property in includeProperties.
                    Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }

            }
            return query.ToList();
        }
    }
}
