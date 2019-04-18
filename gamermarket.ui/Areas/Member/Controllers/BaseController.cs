using GamerMarket.Model.Model.Entities;
using GamerMarket.UI.Attributes;
using System.Web.Mvc;

namespace GamerMarket.UI.Areas.Member.Controllers
{
    [Roles(UserRole.Admin, UserRole.SuperAdmin, UserRole.Member)]
    public class BaseController : Controller
    {
       
    }
}