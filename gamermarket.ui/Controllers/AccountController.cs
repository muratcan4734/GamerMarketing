using GamerMarket.Model.Model.Entities;
using GamerMarket.Service.Service.Concrete;
using GamerMarket.Service.Service.TransferObjects.VM;
using GamerMarket.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GamerMarket.UI.Controllers
{
    public class AccountController : Controller
    {

        AppUserService _appUserService;

        public AccountController()
        {
            _appUserService = new AppUserService();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AppUser newUser, HttpPostedFileBase Image)
        {
            newUser.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", Image);

            if (newUser.ImagePath=="0" ||newUser.ImagePath=="1" || newUser.ImagePath=="2")
            {
                //Varsayılan Foto
                newUser.ImagePath = "/Uploads/Anon.png";
            }
            newUser.Role = UserRole.Member;
            
            _appUserService.Add(newUser);
            
            return RedirectToAction("Login","Account");
        }



        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }


        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser currentUser = _appUserService.GetByDefault(x=>x.UserName==HttpContext.User.Identity.Name);

                if (currentUser.Role == UserRole.Admin)
                {
                    return RedirectToAction("Index", "Home", new { area = "admin" });
                }
                else if (currentUser.Role == UserRole.Member)
                {
                    return RedirectToAction("Index", "Home", new { area = "member" });
                }
                else if (currentUser.Role == UserRole.Banned)
                {
                    //Size kalmış
                    return RedirectToAction("");
                }
                else
                {
                    //Eğer böyle bir kullanıcı yoksa kayıt sayfasına yönlendir.
                    return RedirectToAction("Register");
                }
            }
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM data)
        {
            if (ModelState.IsValid)
            {
                if (_appUserService.CheckCredentials(data.UserName,data.Password))
                {
                    //Giriş yapan kullanıcı yakalanır..
                    AppUser currentUser = _appUserService.GetByDefault(x => x.UserName == data.UserName && x.Password == data.Password);

                    //UserName eşsiz olmalı!
                    string cookie = currentUser.UserName;


                    FormsAuthentication.SetAuthCookie(cookie, true);


                    if (currentUser.Role==UserRole.Admin)
                    {
                        return RedirectToAction("Index", "Home", new { area = "admin" });
                    }
                    else if (currentUser.Role==UserRole.Member)
                    {
                        return RedirectToAction("Index", "Home", new { area = "member" });
                    }
                    else if (currentUser.Role == UserRole.Banned)
                    {
                        //Size kalmış
                        return RedirectToAction("");
                    }
                    else
                    {
                        //Eğer böyle bir kullanıcı yoksa kayıt sayfasına yönlendir.
                        return RedirectToAction("Register");
                    }

                }
                else
                {
                    ViewBag.Message = "Kullanıcı Adı veya Parola Hatalı!";
                    return View();
                }
            }
            return View();
        }
    }
}