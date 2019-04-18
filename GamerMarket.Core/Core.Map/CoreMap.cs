using GamerMarket.Core.Core.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamerMarket.Core.Core.Map
{
    public class CoreMap<T> : EntityTypeConfiguration<T> where T : CoreEntity
    {
        //FLUENT API

        //Core entity tüm entity sınıflarına miras verecek sınıftır. Su an yaptıgımız ise tüm map sınıflarına yani tüm db sınıflarının ortak map sınıfını yaratmaktır. Aynı zamanda Core Entity'nin burada db kurallarınıda oluşturuyoruz.

        //Nasıl core entity tüm entity sınıflarına miras veriyorsa, coremapte tüm map sınıflarına miras verecektir.
        public CoreMap()
        {
            Property(core => core.ID).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnOrder(1);
            Property(core => core.Status).IsOptional();

            Property(core => core.CreatedDate).HasColumnType("datetime2");
            Property(core => core.ModifiedDate).HasColumnType("datetime2");

            Property(core => core.CreatedBy).IsOptional();
            Property(core => core.ModifiedBy).IsOptional();
        }
    }
}
