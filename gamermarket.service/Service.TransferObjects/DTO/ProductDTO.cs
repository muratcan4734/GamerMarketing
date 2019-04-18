using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerMarket.Service.Service.TransferObjects.DTO
{
    public class ProductDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public short UnitsInStock { get; set; }
        public string Quantity { get; set; }
        public double Discount { get; set; }
        public string ImagePath { get; set; }
        public bool DisplayOnWeb { get; set; }
        public bool DisplayOnMobile { get; set; }
        public Guid CategoryID { get; set; }
    }
}
