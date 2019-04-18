using GamerMarket.Core.Core.Map;
using GamerMarket.Model.Model.Entities;


namespace GamerMarket.Map.Map.EntityMaps
{
    public class OrderMap:CoreMap<Order>
    {
        public OrderMap()
        {

            //https://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx


            ToTable("dbo.Orders");
            Property(o => o.TotalPrice).IsOptional();
            Property(o => o.OrderDate).HasColumnType("datetime2").IsOptional();

            //Order - AppUser İlişkisi
            HasRequired(o => o.AppUser)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.AppUserID)
                .WillCascadeOnDelete(false);

            //Order - Order Detail İlişkisi
            HasMany(order => order.OrderDetails)
                .WithRequired(od => od.Order)
                .HasForeignKey(od => od.OrderID)
                .WillCascadeOnDelete(false);

        }
    }
}
