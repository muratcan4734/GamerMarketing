using GamerMarket.Model.Model.Entities;
using GamerMarket.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamerMarket.UI.Areas.Admin.Controllers
{
    
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}