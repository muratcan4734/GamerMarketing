using GamerMarket.Model.Model.Entities;
using GamerMarket.Service.Service.Abstract;
using GamerMarket.Core.Core.Entity.Enums;

namespace GamerMarket.Service.Service.Concrete
{
    public class CategoryService:BaseService<Category>
    {
        public int CategoryCount() => GetDefault(x => x.Status == Status.Active || x.Status == Status.Updated).Count;
    }
}