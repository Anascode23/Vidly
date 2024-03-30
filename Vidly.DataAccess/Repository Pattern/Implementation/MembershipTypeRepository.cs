using Vidly.Access.Data;
using Vidly.Models;
using Vidly.Repository_Pattern.Interface;

namespace Vidly.Repository_Pattern.Implementation
{
    public class MembershipTypeRepository : Repository<MembershipType>, IMembershipType
    {
        private readonly VidlyDBContext _vidlyDB;

        public MembershipTypeRepository(VidlyDBContext vidlyDB) : base(vidlyDB)
        {

            _vidlyDB = vidlyDB;
        }

        public void Update(MembershipType obj)
        {
            _vidlyDB.Update(obj);
        }
    }
}
