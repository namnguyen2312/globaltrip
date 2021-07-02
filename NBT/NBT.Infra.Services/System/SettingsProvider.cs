using NBT.Core.Domain.System;
using NBT.Core.Services.ApplicationServices.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Infra.Services.System
{
    public class SettingsProvider : ISettingsProvider
    {
        public static readonly Settings MetaTitle = new Settings { Id = 1, Name = "Meta title" };
        public static readonly Settings MetaDescription = new Settings { Id = 2, Name = "Meta description" };
        public static readonly Settings MetaKeyword = new Settings { Id = 3, Name = "Meta keywork" };
        public static readonly Settings CompanyName = new Settings { Id = 4, Name = "Tên công ty" };
        public static readonly Settings Phone = new Settings { Id = 5, Name = "Điện thoại" };
        public static readonly Settings Address = new Settings { Id = 6, Name = "Địa chỉ" };
        public static readonly Settings CompanyEmail = new Settings { Id = 7, Name = "Email CTY" };
        public static readonly Settings EmailAdmin = new Settings { Id = 8, Name = "Email admin" };
        public static readonly Settings PasswordEmail = new Settings { Id = 9, Name = "Password email admin" };
        public static readonly Settings EmailNoti = new Settings { Id = 10, Name = "Email thông báo" };

        public static readonly Settings Facebook = new Settings { Id = 11, Name = "Facebook" };
        public static readonly Settings Twitter = new Settings { Id = 12, Name = "Twitter" };
        public static readonly Settings Instagram = new Settings { Id = 13, Name = "Instagram" };
        public static readonly Settings CompanyName1 = new Settings { Id = 14, Name = "Tên cty liên kết 1" };
        public static readonly Settings Phone1 = new Settings { Id = 15, Name = "Điện thoại cty liên kết 1" };
        public static readonly Settings Address1 = new Settings { Id = 16, Name = "Địa chỉ cty liên kết 1" };
        public static readonly Settings CompanyEmail1 = new Settings { Id = 17, Name = "Email cty liên kết 1" };
        public IEnumerable<Settings> GetAll()
        {
            return new[]
            {
                MetaTitle,
                MetaDescription,
                MetaKeyword,
                CompanyName,
                Phone,
                Address,
                CompanyEmail,
                EmailAdmin,
                PasswordEmail,
                EmailNoti,
                Facebook,
                Twitter,
                Instagram,
                CompanyName1,
                Phone1,
                Address1,
                CompanyEmail1
            };
        }
    }
}
