using GamerMarket.Core.Core.Map;
using GamerMarket.Model.Model.Entities;


namespace GamerMarket.Map.Map.EntityMaps
{
    public class ProductMap:CoreMap<Product>
    {
        public ProductMap()
        {
            ToTable("dbo.Products");
            Property(p => p.UnitsInStock).IsOptional();
            Property(p => p.Price).IsOptional();
            Property(p => p.Discount).IsOptional();
            Property(p => p.DisplayOnMobile).IsOptional();
            Property(p => p.DisplayOnWeb).IsOptional();
        }
    }
}