using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBT.Web.Framework.Models.Security
{
    public class AppUserVm
    {
        public string Id { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public string PhoneNumber { set; get; }
        public string Email { set; get; }
        public string FullName { set; get; }
        public string Address { set; get; }
        public DateTimeOffset BirthDay { set; get; }
        public bool Gender { set; get; }
        public bool IsActive { set; get; }
        public bool IsSystemAccount { set; get; }
        public DateTimeOffset CreatedDate { set; get; }
        public DateTimeOffset UpdatedDate { set; get; }
        public string CreatedBy { set; get; }
        public IEnumerable<AppGroupVm> Groups { set; get; }
    }
}