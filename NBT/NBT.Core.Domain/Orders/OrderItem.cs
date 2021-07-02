using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Domain.Orders
{
    public class OrderItem: BaseEntity<long>
    {
        public long OrderId { set; get; }
        public long CodeId { set; get; }
        public string Code { set; get; }
        [MaxLength(128)]
        public string Name { set; get; }
        public decimal Quantity { set; get; }
        public decimal Price { set; get; }
        [MaxLength(512)]
        public string Image { set; get; }
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime FromDate { set; get; }
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime ToDate { set; get; }
    }
}
