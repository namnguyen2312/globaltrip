using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NBT.Core.Services.ApplicationServices.Orders;
using NBT.Core.Services.ApplicationServices.System;

namespace NBT.Web.Api.Controllers.Orders
{
    [RoutePrefix("api/orderDetail")]
    [Authorize]
    public class OrderDetailController : BaseApiController
    {
        IOrderItemService _orderItemService;
        public OrderDetailController(IErrorService errorService
            , IOrderItemService orderItemService) : base(errorService)
        {
            _orderItemService = orderItemService;
        }

        [Route("getById/{id:long}")]
        [HttpGet]
        //[Authorize(Roles = nameof(PermissionProvider.ViewGroup))]
        public HttpResponseMessage GetById(HttpRequestMessage request, long id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _orderItemService.GetByOrderId(id);
                response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }
    }
}
