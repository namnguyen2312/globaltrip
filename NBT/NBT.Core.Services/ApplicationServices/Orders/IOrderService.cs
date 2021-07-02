using NBT.Core.Domain.Orders;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Services.ApplicationServices.Orders
{
    public interface IOrderService : IService<Order>
    {
        IPagedList<Order> GetAll(int pageIndex = 1, int pageSize = 20, string filter = ""
            , DateTimeOffset? fromDate = null, DateTimeOffset? toDate = null, bool? isVerify = null);
    }
}
