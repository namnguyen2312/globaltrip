using NBT.Core.Common.Utils;
using NBT.Core.Domain.Orders;
using NBT.Core.Services.ApplicationServices.Orders;
using NBT.Core.Services.Data;
using NBT.Core.Services.DomainServices.Orders;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Infra.Services.Orders
{
    public class OrderService : ServiceBase<Order>, IOrderService
    {
        IOrderRepository _orderRepo;
        public OrderService(IUnitOfWork unitOfWork, IOrderRepository orderRepo) : base(unitOfWork, orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public IPagedList<Order> GetAll(int pageIndex = 1, int pageSize = 20, string filter = ""
            , DateTimeOffset? fromDate = null, DateTimeOffset? toDate = null, bool? isVerify = null)
        {
            var query = _orderRepo.TableNoTracking;

            if (isVerify != null && isVerify.Value)
                query = query.Where(x => x.IsVerify == !isVerify);
            if (!string.IsNullOrWhiteSpace(filter))
                query = query.Where(
                    x => x.CustomerName.Contains(filter)
                || x.CustomerPhone.Contains(filter)
                || x.CustomerEmail.Contains(filter));
            if (fromDate != null)
            {
                fromDate = DateTimeHelper.FromDate(fromDate.Value);
                query = query.Where(x => x.CreatedDate >= fromDate.Value);
            }
            if (toDate != null)
            {
                toDate = DateTimeHelper.ToDate(toDate.Value);
                query = query.Where(x => x.CreatedDate <= toDate.Value);
            }

            return query.OrderByDescending(x => x.CreatedDate).ThenBy(x => x.CustomerName).ToPagedList(pageIndex, pageSize);
        }
    }
}
