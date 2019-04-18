using GamerMarket.Core.Core.Entity;
using GamerMarket.Core.Core.Service;
using GamerMarket.DAL.DA.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace GamerMarket.Service.Service.Abstract
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        //Bu sınıfın amacı, ortak tüm metotlarımızı tanımlamak, yani tüm entitylerimizin yani tablolarımızın işine yarayacak metotları bir kere yazmak ve daha sonrasında bu sınıfı ve içerisindeki metotları miras vermek.
        //Eğer kendilerine özel bir metoda sahip olacaklarsa, onları kendi sınıflarında tanımlıyor olacağız.


        private GamerMarketContext _context;
        //protected DbSet<T> table;
        public BaseService()
        {
            //table = _context.Set<T>();
            _context = new GamerMarketContext();
        }

        public bool Add(T item)
        {
            try
            {
                //table.Add(item);
                _context.Set<T>().Add(item);
                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Add(List<T> items)
        {
            try
            {
                _context.Set<T>().AddRange(items);
                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Any(Expression<Func<T, bool>> exp) => _context.Set<T>().Any(exp);


        public T GetByDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).FirstOrDefault();

        public List<T> GetDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).ToList();

        public T GetById(Guid id) => _context.Set<T>().Find(id); //Bodied Member



        public bool Remove(T item)
        {
            try
            {
                item.Status = Core.Core.Entity.Enums.Status.Deleted;
                Update(item);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(Guid id)
        {
            try
            {
                T item = GetById(id);
                item.Status = Core.Core.Entity.Enums.Status.Deleted;
                Update(item);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveAll(Expression<Func<T, bool>> exp)
        {
            try
            {
                foreach (var item in GetDefault(exp))
                {
                    item.Status = Core.Core.Entity.Enums.Status.Deleted;
                    Update(item);
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        //Save ve Update gibi metotları başka metotlar içerisine yazmak SOLID prensiplerine ters düşecektir. Single Responsibility Yani her metot bir iş yapar ve birden fazla işe bulaşmaz gibi :). Ancak Ekleme adımlarına baktıgımızda kayıt edilmeside teknik olarak hala ekleme işlemine dahildir ve bu değişmez. Bu nedenle bırakılabilir. Bu noktada test edip etmeyeceğimiz ve bu testlerin veritabanında kayıt edilip edilmemesi durumlarına göre içerde veya dışarıda bırakılabilir. Yani metotları test ederken eğer gerçekten veritabanına kayıt edilmesin diyorsanız, bu save ve update metotlarını, ekleme ve silme gübü metotlar içerisinden kaldırabilirsiniz. O zaman mvc projesi altında kullanıcıdan gelen isitekleri değerlendirirken bu metotları ayrıca çağırmanız gerekecektir.
        public int Save() => _context.SaveChanges();

        public bool Update(T item)
        {
            try
            {
                T itemToBeUpdated = GetById(item.ID);
                DbEntityEntry entry = _context.Entry(itemToBeUpdated);
                entry.CurrentValues.SetValues(item);
                Save(); //İstersek, Save sonucundan dönen değerin sıfırdan büyük olmasına da bakılabilirdi.
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<T> GetActive()
        {
            return _context.Set<T>().Where(x => x.Status == Core.Core.Entity.Enums.Status.Active || x.Status == Core.Core.Entity.Enums.Status.Updated).ToList();
        }
    }
}
