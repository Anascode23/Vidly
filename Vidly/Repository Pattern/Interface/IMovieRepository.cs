using Vidly.Models;

namespace Vidly.Repository_Pattern.Interface
{
    public interface IMovieRepository : IRepository<Movie>
    {
        void Update(Movie obj);
    }

}
