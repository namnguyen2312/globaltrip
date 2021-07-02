using NBT.Core.Services.ApplicationServices.System;
using NBT.Infra.Services.Blog;
using NBT.Infra.Services.System;
using NBT.Web.Framework.Core;
using NBT.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NBT.Web.Controllers
{
    public class BaseController : Controller
    {
        protected WebSettingsVm _webSettings;
        public BaseController()
        {

        }

        protected void LoadDefaultMetaSEO()
        {
            var webSetting = this.WebSetting;
            ViewBag.Title = webSetting.MetaTitle;
            ViewBag.Keyword = webSetting.MetaKeyword;
            ViewBag.Description = webSetting.MetaDescription;
        }

        private void UpdateWebSettings()
        {
            _webSettings = new WebSettingsVm();
            _webSettings.Address = WebSettings.Address;
            _webSettings.Address1 = WebSettings.Address1;
            _webSettings.CompanyEmail = WebSettings.CompanyEmail;
            _webSettings.CompanyEmail1 = WebSettings.CompanyEmail1;
            _webSettings.CompanyName = WebSettings.CompanyName;
            _webSettings.CompanyName1 = WebSettings.CompanyName1;
            _webSettings.EmailAdmin = WebSettings.EmailAdmin;
            _webSettings.EmailNoti = WebSettings.EmailNoti;
            _webSettings.Facebook = WebSettings.Facebook;
            _webSettings.Instagram = WebSettings.Instagram;
            _webSettings.MetaDescription = WebSettings.MetaDescription;
            _webSettings.MetaKeyword = WebSettings.MetaKeyword;
            _webSettings.MetaTitle = WebSettings.MetaTitle;
            _webSettings.PasswordEmail = WebSettings.PasswordEmail;
            _webSettings.Phone = WebSettings.Phone;
            _webSettings.Phone1 = WebSettings.Phone1;
            _webSettings.Twitter = WebSettings.Twitter;
        }

        protected WebSettingsVm WebSetting
        {
            get
            {
                if (string.IsNullOrEmpty(WebSettings.Address))
                    LoadSettings();
                if (object.ReferenceEquals(_webSettings, null))
                    UpdateWebSettings();
                return _webSettings;

            }
        }

        private void LoadSettings()
        {

            var settings = ServiceFactory.Get<ISettingsService>().GetAll();

            WebSettings.Address = settings.First(x => x.Id == SettingsProvider.Address.Id).Value;
            WebSettings.Address1 = settings.First(x => x.Id == SettingsProvider.Address1.Id).Value;
            WebSettings.CompanyEmail = settings.First(x => x.Id == SettingsProvider.CompanyEmail.Id).Value;
            WebSettings.CompanyEmail1 = settings.First(x => x.Id == SettingsProvider.CompanyEmail1.Id).Value;
            WebSettings.CompanyName = settings.First(x => x.Id == SettingsProvider.CompanyName.Id).Value;
            WebSettings.CompanyName1 = settings.First(x => x.Id == SettingsProvider.CompanyName1.Id).Value;
            WebSettings.EmailAdmin = settings.First(x => x.Id == SettingsProvider.EmailAdmin.Id).Value;
            WebSettings.EmailNoti = settings.First(x => x.Id == SettingsProvider.EmailNoti.Id).Value;
            WebSettings.Facebook = settings.First(x => x.Id == SettingsProvider.Facebook.Id).Value;
            WebSettings.Instagram = settings.First(x => x.Id == SettingsProvider.Instagram.Id).Value;
            WebSettings.MetaDescription = settings.First(x => x.Id == SettingsProvider.MetaDescription.Id).Value;
            WebSettings.MetaKeyword = settings.First(x => x.Id == SettingsProvider.MetaKeyword.Id).Value;
            WebSettings.MetaTitle = settings.First(x => x.Id == SettingsProvider.MetaTitle.Id).Value;
            WebSettings.PasswordEmail = settings.First(x => x.Id == SettingsProvider.PasswordEmail.Id).Value;
            WebSettings.Phone = settings.First(x => x.Id == SettingsProvider.Phone.Id).Value;
            WebSettings.Phone1 = settings.First(x => x.Id == SettingsProvider.Phone1.Id).Value;
            WebSettings.Twitter = settings.First(x => x.Id == SettingsProvider.Twitter.Id).Value;

        }
    }
}