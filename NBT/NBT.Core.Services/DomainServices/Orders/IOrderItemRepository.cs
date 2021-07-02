using NBT.Core.Domain.Orders;
using NBT.Core.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Services.DomainServices.Orders
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
    }
}
