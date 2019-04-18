using GamerMarket.Model.Model.Entities;
using GamerMarket.Service.Service.Abstract;
using GamerMarket.Core.Core.Entity.Enums;

namespace GamerMarket.Service.Service.Concrete
{
    public class AppUserService : BaseService<AppUser>
    {
        public bool CheckCredentials(string userName
            , string password) => Any(x => x.UserName == userName && x.Password == password);

        public int MemberCount() => GetDefault(x => (x.Status == Status.Active || x.Status == Status.Updated) && x.Role==UserRole.Member).Count;
    }
}