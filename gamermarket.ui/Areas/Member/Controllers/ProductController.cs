using GamerMarket.Service.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamerMarket.UI.Areas.Member.Controllers
{
    public class ProductController : BaseController
    {
        ProductService _productService;

        public ProductController()
        {
            _productService = new ProductService();
        }

        public ActionResult Detail(Guid? id)
        {
            if (id == null) return RedirectToAction("Index", "Home", new { area = "Member" });
            return View(_productService.GetById((Guid)id));
        }
    }
}