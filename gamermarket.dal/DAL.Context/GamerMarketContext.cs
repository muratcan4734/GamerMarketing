using GamerMarket.Core.Core.Entity;
using GamerMarket.Map.Map.EntityMaps;
using GamerMarket.Model.Model.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;


namespace GamerMarket.DAL.DA.Context
{
    public class GamerMarketContext : DbContext
    {
        public GamerMarketContext() : base("GamerMarketDB") { }

        //Map sınıflarında yazdığımız kurallarımızı ekliyoruz. Bunun için modellerin (entitylerin) oluşma anında çalışan onModelCreating metodunu yani modelleri tabloya dönüştüren metodu override ederek çağıyoruyoz. DB kurallarımızı da dahil etmesini sağlıyoruz.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            base.OnModelCreating(modelBuilder);
        }

        //Dbsetleri oluşturmazsak, tablolar oluşmaz.
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public override int SaveChanges()
        {
            //Otomatik loglama amaçlı kullanılan bazı özelliklerin doldurulması için, savechanges metodunu override ediyoruz.

            //Yeni eklenen veya güncellenen tüm entry yani kayıtları yakalıyoruz.

            var modifiedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            //Hem eklemede hem de güncellemede kullanılacak olan ortak değerleri bir kere de yakalıyoruz.
            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            DateTime date = DateTime.Now;
            //IP Yakalama Utility içerisine atılacak
            string ip = string.Empty;


            //Yeni eklenen ve güncellenen tüm kayıtlarda geziyoruz.
            foreach (var item in modifiedEntries)
            {
                //hangi entity sınıfından geleceğini bilmiyoruz. Ortak tip olan coreEntity olarak yakalıyoruz.
                CoreEntity entity = item.Entity as CoreEntity;

                if (item != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        entity.Status = Core.Core.Entity.Enums.Status.Active;
                        entity.CreatedADUserName = identity;
                        entity.CreatedComputerName = computerName;
                        entity.CreatedDate = date;
                        entity.CreatedIP = ip;
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        if (entity.Status != Core.Core.Entity.Enums.Status.Deleted)
                        {
                            entity.Status = Core.Core.Entity.Enums.Status.Updated;
                        }
                        entity.ModifiedADUserName = identity;
                        entity.ModifiedComputerName = computerName;
                        entity.ModifiedDate = date;
                        entity.ModifiedIP = ip;
                    }
                }
            }


            return base.SaveChanges();
        }


    }
}