using Vidly.Data;
using Vidly.Models;
using Vidly.Repository_Pattern.Interface;

namespace Vidly.Repository_Pattern.Implementation
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly VidlyDBContext _vidlyDB;

        public CustomerRepository(VidlyDBContext vidlyDB) : base(vidlyDB)
        {
            _vidlyDB = vidlyDB;
        }

        public void Update(Customer obj)
        {
            _vidlyDB.Update(obj);
        }
    }
}
