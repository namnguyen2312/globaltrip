using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NBT.Web.Framework.Models.Cart
{
    public class OrderItemVm
    {
        public string Guid { set; get; }
        public long Id { set; get; }
        public string Code { set; get; }
        public string Alias { set; get; }
        public decimal Quantity { set; get; }
        public decimal Price { set; get; }
        public string Name { set; get; }
        public string Image { set; get; }
        public DateTimeOffset FromDate { set; get; }
        public DateTimeOffset ToDate { set; get; }
    }
}