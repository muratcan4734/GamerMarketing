using GamerMarket.Service.Service.TransferObjects.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamerMarket.UI.Areas.Member.Models
{
    public class ProductCart
    {
        //Bu sınıf sepetimizdeki ürünleri tutacak nesneler üretir.

        //Bu sınıftan üretilen sepet, kendi içerisinde dictionary yani sözlük tipinde verilerini saklayacaktır.
        //Dictionary key-value yani anahtar-değer ikilisi şeklinde verilerimizi saklar.

        private Dictionary<Guid, CartProductVM> _cart = null;

        public ProductCart()
        {
            _cart = new Dictionary<Guid, CartProductVM>();
        }

        public List<CartProductVM> CartProductList
        {
            get
            {
                return _cart.Values.ToList();
            }
        }

        #region Sepete Ürün Ekleme
        public void AddCart(CartProductVM item)
        {
            //Eğer sepette yoksa yeni ürün olarak ekle
            if (!_cart.ContainsKey(item.ID))
            {
                _cart.Add(item.ID, item);
            }
            else
            {
                //Eğer zaten ürün sepette varsa, miktarını arttır.
                _cart[item.ID].Quantity++;
            }
        }
        #endregion

        #region Sepetten Ürün Silme

        public void RemoveCart(Guid id)
        {
            _cart.Remove(id);
        }

        #endregion

        #region Sepetteki Ürün Miktarını Azaltma

        public void DecreaseCart(Guid id)
        {
            _cart[id].Quantity--;
            if (_cart[id].Quantity <= 0) _cart.Remove(id);
        }

        #endregion

        #region Sepetteki Ürün Miktarını Arttırma
        public void IncreaseCart(Guid id)
        {
            _cart[id].Quantity++;
        }
        #endregion
    }
}