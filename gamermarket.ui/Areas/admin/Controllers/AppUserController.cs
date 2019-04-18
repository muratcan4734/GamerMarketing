using GamerMarket.Model.Model.Entities;
using GamerMarket.Service.Service.Concrete;
using GamerMarket.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamerMarket.UI.Areas.Admin.Controllers
{
    public class AppUserController : Controller
    {
        AppUserService _appUserService;
        public AppUserController()
        {
            _appUserService = new AppUserService();
        }
        public ActionResult List()
        {
            return View(_appUserService.GetActive());
        }
        [HttpGet]
        public ActionResult Update(Guid id)
        {
            return View(_appUserService.GetById(id));
        }
        [HttpPost]
        public ActionResult Update(AppUser data,HttpPostedFileBase Image)
        {
            data.ImagePath = ImageUploader.UploadSingleImage("/Uploads/", Image);

            AppUser guncellenecek = _appUserService.GetById(data.ID);

            if (data.ImagePath != "0" && data.ImagePath != "1" && data.ImagePath != "2")
            {
                //Eğer bu hatalardan biri alınmadıysa, kullanıcı yeni bir görsel eklemiştir.
                guncellenecek.ImagePath = data.ImagePath;
            }

            guncellenecek.Name = data.Name;
            guncellenecek.LastName = data.LastName;
            guncellenecek.Email = data.Email;
            guncellenecek.Password = data.Password;
            guncellenecek.Role = data.Role;
            _appUserService.Update(guncellenecek);

            return RedirectToAction("List");
        }
    }
}