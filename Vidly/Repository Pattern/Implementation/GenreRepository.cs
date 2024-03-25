using Vidly.Data;
using Vidly.Models;
using Vidly.Repository_Pattern.Interface;

namespace Vidly.Repository_Pattern.Implementation
{
    public class GenreRepository : Repository<Genre>, IGenre
    {
        private readonly VidlyDBContext _vidlyDB;

        public GenreRepository(VidlyDBContext vidlyDB) : base(vidlyDB)
        {

            _vidlyDB = vidlyDB;
        }

        public void Update(Genre obj)
        {
            _vidlyDB.Update(obj);
        }
    }
}
