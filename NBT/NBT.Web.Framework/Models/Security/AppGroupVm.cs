using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBT.Web.Framework.Models.Security
{
    public class AppGroupVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<AppRoleVm> Roles { set; get; }
    }
}