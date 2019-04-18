using GamerMarket.Core.Core.Entity;
using System;


namespace GamerMarket.Model.Model.Entities
{
    public class OrderDetail:CoreEntity
    {
        public Guid ProductID { get; set; }
        public virtual Product Product { get; set; }
        public Guid OrderID { get; set; }
        public virtual Order Order { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
    }
}