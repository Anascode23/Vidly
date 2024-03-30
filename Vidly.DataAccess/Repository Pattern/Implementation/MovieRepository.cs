using Vidly.Access.Data;
using Vidly.Models;
using Vidly.Repository_Pattern.Interface;

namespace Vidly.Repository_Pattern.Implementation
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private readonly VidlyDBContext _vidlyDB;

        public MovieRepository(VidlyDBContext vidlyDB) : base(vidlyDB)
        {
            _vidlyDB = vidlyDB;
        }

        public void Update(Movie obj)
        {
            _vidlyDB.Update(obj);
        }
    }
}
