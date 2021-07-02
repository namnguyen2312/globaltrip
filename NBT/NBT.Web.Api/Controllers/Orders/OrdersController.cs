using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NBT.Core.Domain.Orders;
using NBT.Core.Services.ApplicationServices.Orders;
using NBT.Core.Services.ApplicationServices.System;
using NBT.Web.Framework.Core;

namespace NBT.Web.Api.Controllers.Orders
{
    [RoutePrefix("api/orders")]
    [Authorize]

    public class OrdersController : BaseApiController
    {
        IOrderService _orderService;
        public OrdersController(IErrorService errorService,
            IOrderService orderService) : base(errorService)
        {
            _orderService = orderService;
        }
        [Route("getAll")]
        [HttpGet]
        //[Authorize(Roles = nameof(PermissionProvider.ViewOrder))]
        public HttpResponseMessage GetAll(HttpRequestMessage request, int page, int pageSize
            , DateTimeOffset? fromDate = null, DateTimeOffset? toDate = null, string filter = null
            , bool? isVerify = null)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var model = _orderService.GetAll(page + 1, pageSize, filter, fromDate, toDate, isVerify);

                PaginationSet<Order> pagedSet = new PaginationSet<Order>()
                {
                    Page = page,
                    TotalCount = model.TotalItemCount,
                    TotalPages = (int)Math.Ceiling((decimal)model.TotalItemCount / pageSize),
                    Items = model
                };
                response = request.CreateResponse(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [Route("Update")]
        [HttpPut]
        //[Authorize(Roles = nameof(PermissionProvider.AddArea))]
        public HttpResponseMessage Update(HttpRequestMessage request, Order order)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage reponse = null;
                if (!ModelState.IsValid)
                {
                    reponse = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _orderService.Update(order);

                    reponse = request.CreateResponse(HttpStatusCode.OK, order);
                }
                return reponse;

            });
        }

    }
}
