using NBT.Core.Common.Helper;
using NBT.Core.Services.ApplicationServices.System;
using NBT.Web.Framework.Core;
using NBT.Web.Framework.Models.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NBT.Web.Controllers
{
    public class ContactController : BaseController
    {
        IConverseService _converseService;
        public ContactController(IConverseService converseService)
        {
            _converseService = converseService;
        }

        public ActionResult Index()
        {
            this.LoadDefaultMetaSEO();
            var model = _converseService.GetAll(true);
            ViewBag.WebSettings = this.WebSetting;
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult ContactForm()
        {
            ContactFormVm contactFormVm = new ContactFormVm();
            if (TempData["ContactForm"] != null)
                return PartialView(TempData["ContactForm"]);
            return PartialView(contactFormVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ContactFormVm contactFormVm)
        {
            if (!ModelState.IsValid)
            {
                TempData["ContactForm"] = contactFormVm;
                return RedirectToAction("Index");
            }
            var settings = this.WebSetting;
            MailHelper.SendMail(contactFormVm.Email, "Xác nhận đã gởi thông tin liên lạc", "Chúng tôi sẽ phản hồi lại khách hàng trong thời gian sớm nhất"
                , settings.EmailAdmin
                , settings.PasswordEmail
                , "CÔNG TY TNHH THƯƠNG MẠI VÀ DỊCH VỤ DU LỊCH LỮ HÀNH TOÀN CẦU");
            MailHelper.SendMail(this.WebSetting.EmailAdmin, contactFormVm.Title, "Khách hàng " + contactFormVm.Name + " " + contactFormVm.MessageBox
                , settings.EmailAdmin
                , settings.PasswordEmail
                , contactFormVm.Name);
            return RedirectToAction("Index", "Tour");
        }
    }
}