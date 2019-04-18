using GamerMarket.Core.Core.Map;
using GamerMarket.Model.Model.Entities;

namespace GamerMarket.Map.Map.EntityMaps
{
    public class OrderDetailMap:CoreMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            ToTable("dbo.OrderDetails");
            Property(od => od.UnitPrice).IsOptional();
            Property(od => od.Quantity).IsOptional();

            //Order Detail - Product İlişkisi
            HasRequired(od => od.Product)
                .WithMany(prd => prd.OrderDetails)
                .HasForeignKey(od => od.ProductID)
                .WillCascadeOnDelete(false);
        }
    }
}
