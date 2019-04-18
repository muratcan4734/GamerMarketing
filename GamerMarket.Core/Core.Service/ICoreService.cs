using GamerMarket.Core.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GamerMarket.Core.Core.Service
{
    public interface ICoreService<T> where T:CoreEntity
    {
        //Genel olarak tüm entitylerin sahip olacağı davranışları tanımlıyoruz.

        bool Add(T item);

        /// <summary>
        /// Toplu Veri Eklemek İçin Kullanabiliriz.
        /// </summary>
        /// <param name="items">List Tipinde Elemanlar Almalıdır.</param>
        bool Add(List<T> items);
        bool Update(T item);
        bool Remove(T item);
        bool Remove(Guid id);
        T GetById(Guid id);
        int Save();
        bool RemoveAll(Expression<Func<T,bool>> exp);
        T GetByDefault(Expression<Func<T, bool>> exp);
        List<T> GetDefault(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        List<T> GetActive();

    }
}
