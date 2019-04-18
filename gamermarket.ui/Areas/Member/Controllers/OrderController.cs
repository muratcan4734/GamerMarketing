using GamerMarket.Model.Model.Entities;
using GamerMarket.Service.Service.Concrete;
using GamerMarket.UI.Areas.Member.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamerMarket.UI.Areas.Member.Controllers
{
    public class OrderController : BaseController
    {
        AppUserService _appUserService;
        ProductService _productService;
        OrderService _orderService;
        public OrderController()
        {
            _appUserService = new AppUserService();
            _productService = new ProductService();
            _orderService = new OrderService();
        }


        public ActionResult Add()
        {
            if (Session["sepet"]==null)
            {
                return RedirectToAction("Index", "Home");
            }
            //Sepeti yakaladık.
            ProductCart cart = Session["sepet"] as ProductCart;

            //Yeni sipariş oluşturduk.
            Order newOrder = new Order();

            //Siparişi veren kullanıcıyı yakaladık.
            AppUser currentUser = _appUserService.GetByDefault(x => x.UserName == HttpContext.User.Identity.Name);

            //Sipariş ile kullanıcı atamasını yaptık.
            newOrder.AppUserID = currentUser.ID;

            decimal totalPrice = 0;

            //Sepetteki tüm ürünlerde geziyoruz.
            foreach (var item in cart.CartProductList)
            {
                //Sırayla veritabanından ürünleri yakalıyoruz.
                Product nextCartProduct = _productService.GetById(item.ID);

                totalPrice += item.Quantity * Convert.ToDecimal(1 - nextCartProduct.Discount) * item.UnitPrice;

                //Her ürün için yeni bir sipariş detay oluşturuyoruz.
                newOrder.OrderDetails.Add(new OrderDetail
                {
                    ProductID=nextCartProduct.ID,
                    Quantity=item.Quantity,
                    UnitPrice=item.UnitPrice
                });
            }

            newOrder.OrderStatus = OrderStatus.Ordered;
            newOrder.OrderDate = DateTime.Now;
            newOrder.TotalPrice = totalPrice;
            _orderService.Add(newOrder);

            return RedirectToAction("Index", "Home");


           
        }
    }
}