using GamerMarket.Service.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamerMarket.UI.Areas.Admin.Controllers
{
    public class ReportController : BaseController
    {
        public PartialViewResult ProductCount()
        {
            ProductService _productService = new ProductService();
            ViewBag.ProductCount = _productService.ProductCount();
            return PartialView("_ProductCount");
        }

        public PartialViewResult CategoryCount()
        {
            CategoryService _categoryService = new CategoryService();
            ViewBag.CategoryCount = _categoryService.CategoryCount();
            return PartialView("_CategoryCount");
        }

        public PartialViewResult MemberCount()
        {
            AppUserService _appUserService = new AppUserService();
            ViewBag.MemberCount = _appUserService.MemberCount();
            return PartialView("_MemberCount");
        }

        public PartialViewResult OrderCount()
        {
            OrderService _orderService = new OrderService();
            ViewBag.OrderCount = _orderService.PendingOrderCount();
            return PartialView("_OrderCount");
        }

    }
}