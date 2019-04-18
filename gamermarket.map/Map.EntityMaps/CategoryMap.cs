using GamerMarket.Core.Core.Map;
using GamerMarket.Model.Model.Entities;


namespace GamerMarket.Map.Map.EntityMaps
{
    public class CategoryMap:CoreMap<Category>
    {
        public CategoryMap()
        {
            ToTable("dbo.Categories");
            Property(x => x.Name).IsRequired();

            //Product - Category İlişkisi

            HasMany(cat => cat.Products)
                .WithRequired(prd => prd.Category)
                .HasForeignKey(prd => prd.CategoryID)
                .WillCascadeOnDelete(false); //Kategori silinirse product silinmesin diye.

        }
    }
}
