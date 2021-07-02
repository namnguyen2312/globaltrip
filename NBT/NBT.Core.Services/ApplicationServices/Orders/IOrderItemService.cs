using NBT.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Services.ApplicationServices.Orders
{
    public interface IOrderItemService:IService<OrderItem>
    {
        int Add(List<OrderItem> list);

        IEnumerable<OrderItem> GetByOrderId(long id);
    }
}
