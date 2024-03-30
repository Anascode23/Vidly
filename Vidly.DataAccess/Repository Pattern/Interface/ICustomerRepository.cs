using Vidly.Models;

namespace Vidly.Repository_Pattern.Interface
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void Update(Customer obj);
    }
}
