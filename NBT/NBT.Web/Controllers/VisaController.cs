using NBT.Core.Services.ApplicationServices.Immigrant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NBT.Web.Controllers
{
    public class VisaController : Controller
    {
        IVisaService _visaService;
        public VisaController(IVisaService visaService)
        {
            _visaService = visaService;
        }
        // GET: Visa
        public ActionResult Index(string alias)
        {

            var models = _visaService.GetAll(1, 999, "", true);
            if (models.Count == 0)
                return RedirectToAction("Index", "Home");
            ViewBag.Visa = _visaService.GetByAlias(alias);
            if (string.IsNullOrWhiteSpace(alias))
                ViewBag.Visa = models.FirstOrDefault();
            return View(models);
        }
    }
}