using GamerMarket.Model.Model.Entities;
using GamerMarket.Service.Service.Abstract;
using GamerMarket.Core.Core.Entity.Enums;
using System.Collections.Generic;

namespace GamerMarket.Service.Service.Concrete
{
    public class OrderService:BaseService<Order>
    {
        public int PendingOrderCount() => GetDefault(x => (x.Status == Status.Active || x.Status == Status.Updated) && x.OrderStatus == OrderStatus.Ordered).Count;

        public List<Order> ListPendingOrders() => GetDefault(x => (x.Status == Status.Active || x.Status == Status.Updated) && (x.OrderStatus == OrderStatus.Ordered || x.OrderStatus==OrderStatus.PreOrdered));
    }
}