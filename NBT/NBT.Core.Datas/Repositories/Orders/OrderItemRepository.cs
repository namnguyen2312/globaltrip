using NBT.Core.Domain.Orders;
using NBT.Core.Services.DomainServices.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Datas.Repositories.Orders
{
    public class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(MasterDBContext dbContext) : base(dbContext)
        {
        }
    }
}
