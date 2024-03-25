using Vidly.Models;

namespace Vidly.Repository_Pattern.Interface
{
    public interface IGenre : IRepository<Genre>
    {
        void Update(Genre obj);
    }
}
