using GamerMarket.Service.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamerMarket.UI.Areas.Member.Controllers
{
 
    public class HomeController : BaseController
    {
        ProductService _productService;
        public HomeController()
        {
            _productService = new ProductService();
        }

        public ActionResult Index()
        {
            return View(_productService.GetActive());
        }
    }
}