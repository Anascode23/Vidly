using Vidly.Models;

namespace Vidly.Repository_Pattern.Interface
{
    public interface IMembershipType : IRepository<MembershipType>
    {
        void Update(MembershipType obj);
    }
}
