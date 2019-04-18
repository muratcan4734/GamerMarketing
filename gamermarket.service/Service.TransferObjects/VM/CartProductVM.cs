using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerMarket.Service.Service.TransferObjects.VM
{
    public class CartProductVM
    {
        public Guid ID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        //Bu quantity veritabanındaki miktarı değil, sepetteki miktarı gösterecektir. Veritabanındaki yani product sınıfındaki QuantityPerUnit ile alakası yoktur.
        public short Quantity { get; set; }
    }
}
