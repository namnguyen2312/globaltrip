using NBT.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NBT.Web.Controllers
{
    public class CommonController : BaseController
    {
        // GET: Common
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        [OutputCache(Duration = SystemConstants.Hour)]
        public ActionResult Header(string style)
        {
            ViewBag.StyleHeader = style;
            return PartialView(this.WebSetting);
        }

        [ChildActionOnly]
        [OutputCache(Duration = SystemConstants.Hour)]
        public ActionResult Footer()
        {
            
            return PartialView(this.WebSetting);
        }

        [ChildActionOnly]
        [OutputCache(Duration = SystemConstants.Hour)]
        public ActionResult Navigation()
        {
            return PartialView();
        }
    }
}