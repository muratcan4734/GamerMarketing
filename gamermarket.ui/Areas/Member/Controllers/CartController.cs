using GamerMarket.Model.Model.Entities;
using GamerMarket.Service.Service.Concrete;
using GamerMarket.Service.Service.TransferObjects.VM;
using GamerMarket.UI.Areas.Member.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamerMarket.UI.Areas.Member.Controllers
{
    public class CartController : BaseController
    {

        ProductService _productService;
        public CartController()
        {
            _productService = new ProductService();
        }



        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;

                List<CartProductVM> productList = cart.CartProductList.Select(x => new CartProductVM
                {
                    ID = x.ID,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    Quantity = x.Quantity
                }).ToList();
                //Json verinin gönderilmesinin engellenmemesi için allow get yazabilirsiniz.
                return Json(productList, JsonRequestBehavior.AllowGet);
            }
            return Json("Empty", JsonRequestBehavior.AllowGet);
        }


        //Sepete Ekleme
        public ActionResult Add(Guid id)
        {
            //gelen idye ait ürünü yakalıyoruz.
            Product sepeteEklenecekurun = _productService.GetById(id);
            CartProductVM model = new CartProductVM();
            model.ID = sepeteEklenecekurun.ID;
            model.ProductName = sepeteEklenecekurun.Name;
            model.UnitPrice = sepeteEklenecekurun.Price;
            model.Quantity = 1;


            //Session Nedir ? 
            //Server taraflı verileri tutmak için tasarlanmış bir yapıdır.
            //Kullanıcı oturumlarını, sepet vb yapıları client-server iletişimi sırasında saklamamıza yarar.
            //Session object tipinde değer tutar bu nedenle cast etmek gereklidir.
            if (Session["sepet"] != null)
            {
                //Session içerisinde bir sepet varsa
                ProductCart cart = Session["sepet"] as ProductCart;
                cart.AddCart(model);
                //Ürün eklendikten sonra sepetin son halini sessiona at
                Session["sepet"] = cart;
            }
            else
            {
                //Session içerisinde bir sepet yoksa
                ProductCart cart = new ProductCart();
                cart.AddCart(model);
                //Session'ı ilk kez oluşturuyoruz.
                Session.Add("sepet", cart);
            }

            ProductCart cartSon = Session["sepet"] as ProductCart;

            return Json(cartSon.CartProductList);
        }

        public ActionResult IncreaseCart(Guid id)
        {
            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                cart.IncreaseCart(id);
                Session["sepet"] = cart;
            }
            return Json("");
        }

        public ActionResult DecreaseCart(Guid id)
        {
            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                cart.DecreaseCart(id);
                Session["sepet"] = cart;
            }
            return Json("");
        }

        public ActionResult Remove(Guid id)
        {
            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                cart.RemoveCart(id);
                Session["sepet"] = cart;
            }
            return Json("");
        }

    }
}