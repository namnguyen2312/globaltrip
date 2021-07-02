using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NBT.Web.Framework.Models.Cart
{
    public class OrderVm
    {
        [MaxLength(128)]
        [Required]
        public string CustomerName { set; get; }
        [MaxLength(128)]
        [Required]
        public string CustomerPhone { set; get; }
        [MaxLength(128)]
        public string CustomerAddress { set; get; }
        [MaxLength(128)]
        public string CustomerEmail { set; get; }
        public bool IsVerify { set; get; }
        public DateTimeOffset CreatedDate { set; get; }
        public decimal Total { set; get; }
        [MaxLength(512)]
        public string Note { set; get; }
    }
}