namespace GamerMarket.DAL.Migrations
{
    using GamerMarket.Model.Model.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GamerMarket.DAL.DA.Context.GamerMarketContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GamerMarket.DAL.DA.Context.GamerMarketContext context)
        {
            //List<AppUser> defaultUsers = new List<AppUser>();

            //defaultUsers.Add(new AppUser
            //{
            //    Name = "Michael L.",
            //    LastName = "Hardy",
            //    BirthDate = new DateTime(1973, 1, 22),
            //    Address = "Corpus Christi, Texas(TX), 78476",
            //    PhoneNumber = "682-201-6771",
            //    Email = "colt2014@yahoo.com",
            //    ImagePath = "~/Uploads/Michael.jpg",
            //    Role = UserRole.Admin,
            //    Status=Core.Core.Entity.Enums.Status.Active,
            //    UserName="admin",
            //    Password="123"
            //});

            //context.Users.AddRange(defaultUsers);
            //base.Seed(context);
        }
    }
}
