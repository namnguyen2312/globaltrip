using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Domain.Orders
{
    public class Order:BaseEntity<long>
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
