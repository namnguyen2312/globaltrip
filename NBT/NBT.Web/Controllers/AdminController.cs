using Microsoft.AspNet.Identity;
using NBT.Infra.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NBT.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        ApplicationUserManager _userManager;
        public AdminController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }
        public async Task<ActionResult> Index()
        {
            Session["IsAuthorized"] = true;
            //var user = await _userManager.FindByIdAsync(User.Identity.GetUserId());
            //if (!user.IsSystemAccount)
            //    return RedirectToAction("Index", "Home");
            return View();
        }
        
    }
}