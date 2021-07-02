using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NBT.Web.Framework.Models.Customers
{
    public class CustomerVm
    {
        [MaxLength(128)]
        public string CustomerName { set; get; }
        [MaxLength(128)]
        public string CustomerPhone { set; get; }
        [MaxLength(128)]
        public string CustomerAddress { set; get; }
    }
}