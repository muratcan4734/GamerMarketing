using GamerMarket.Model.Model.Entities;
using GamerMarket.Service.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamerMarket.UI.Attributes
{
    public class RolesAttribute:AuthorizeAttribute
    {
        AppUserService _appUserService;
        private UserRole[] _roles;
        public RolesAttribute(params UserRole[] roles)
        {
            _roles = new UserRole[roles.Length];
            _appUserService = new AppUserService();
            Array.Copy(roles, _roles, roles.Length);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //Forms authentication içerisinden gelen userNamei yakaladık.
            string userName = HttpContext.Current.User.Identity.Name;
            //Boş olmadığından emin olduk
            if (!string.IsNullOrWhiteSpace(userName))
            {
                //Kullanıcımızı yakaladık.
                AppUser currentUser = _appUserService.GetByDefault(x => x.UserName == userName);
                //Parametrede belirtilen rolelrden birine kullanıcının rolü uyuyorsa, true, yoksa false dönüyoruz. Bu sayede true dönmezsek, kullanıcı o sayfayı görüntüleyemiyor.
                foreach (var item in _roles)
                {
                    if (currentUser.Role==item)
                    {
                        return true;
                    }
                }

                return false;

            }
            else
            {
                //İstersek Error Controller Açar, ve unauthorized sayfasını hazırlarız.
                HttpContext.Current.Response.Redirect("~/Error/Unauthorized");
                return false;
            }
        }
        
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Error/Unauthorized");
        }

    }
}