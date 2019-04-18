using GamerMarket.Core.Core.Entity;
using System;
using System.Collections.Generic;

namespace GamerMarket.Model.Model.Entities
{
    public class Product : CoreEntity
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public short UnitsInStock { get; set; }
        public string Quantity { get; set; }
        public double Discount { get; set; }
        public string ImagePath { get; set; }
        //Webde ve mobilde gösterme durumu
        public bool DisplayOnWeb { get; set; }
        public bool DisplayOnMobile { get; set; }

        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}