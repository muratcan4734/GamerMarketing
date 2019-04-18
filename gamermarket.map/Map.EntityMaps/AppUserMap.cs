using GamerMarket.Core.Core.Map;
using GamerMarket.Model.Model.Entities;


namespace GamerMarket.Map.Map.EntityMaps
{
    public class AppUserMap:CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.Users");
            Property(user=>user.Role).IsOptional();
            Property(user=>user.UserName).IsRequired();
            Property(user=>user.Password).IsRequired();
            Property(user=>user.Email).IsRequired();
            Property(user=>user.BirthDate).HasColumnType("datetime2").IsOptional();
        }
    }
}
