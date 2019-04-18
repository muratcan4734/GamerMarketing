using GamerMarket.Core.Core.Entity;
using System;
using System.Collections.Generic;

namespace GamerMarket.Model.Model.Entities
{
    public enum UserRole
    {
        None=0,
        Admin=1,
        Member=3,
        Banned=5,
        SuperAdmin=7
    }
    public class AppUser:CoreEntity
    {
        public AppUser()
        {
            Orders = new HashSet<Order>();
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        //Eğer birden fazla foto olacaksa, tablo olarak açmak gerekir.
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        //Sipariş İlişkisi
        public ICollection<Order> Orders{ get; set; }
    }
}