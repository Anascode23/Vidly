namespace Vidly.Repository_Pattern.Interface
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        IMovieRepository Movie { get; }
        void Save();
    }
}
