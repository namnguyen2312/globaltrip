using NBT.Core.Domain.Orders;
using NBT.Core.Services.ApplicationServices.Orders;
using NBT.Core.Services.Data;
using NBT.Core.Services.DomainServices.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Infra.Services.Orders
{
    public class OrderItemService : ServiceBase<OrderItem>, IOrderItemService
    {
        IOrderItemRepository _orderItemRepo;
        public OrderItemService(IUnitOfWork unitOfWork, IOrderItemRepository orderItemRepo) : base(unitOfWork, orderItemRepo)
        {
            _orderItemRepo = orderItemRepo;
        }

        public int Add(List<OrderItem> list)
        {
            try
            {
                return _orderItemRepo.Insert(list);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<OrderItem> GetByOrderId(long id)
        {
            return _orderItemRepo.GetMulti(x => x.OrderId == id).ToList();
        }
    }
}
