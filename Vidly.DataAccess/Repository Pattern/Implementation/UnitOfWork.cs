using Vidly.Access.Data;
using Vidly.Repository_Pattern.Interface;

namespace Vidly.Repository_Pattern.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VidlyDBContext _vidlyDB;
        public ICustomerRepository Customer { get; private set; }

        public IMovieRepository Movie { get; private set; }
        public IGenre Genre { get; private set; }
        public IMembershipType MembershipType { get; private set; }

        public UnitOfWork(VidlyDBContext vidlyDB)
        {
            _vidlyDB = vidlyDB;
            Customer = new CustomerRepository(_vidlyDB);
            Movie = new MovieRepository(_vidlyDB);
            Genre = new GenreRepository(_vidlyDB);
            MembershipType = new MembershipTypeRepository(_vidlyDB);
        }


        public void Save()
        {
            _vidlyDB.SaveChanges();
        }
    }
}
