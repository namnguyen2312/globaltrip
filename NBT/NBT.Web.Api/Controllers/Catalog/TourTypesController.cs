using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NBT.Core.Services.ApplicationServices.Catalog;
using NBT.Core.Services.ApplicationServices.System;

namespace NBT.Web.Api.Controllers.Catalog
{
    [RoutePrefix("api/tourTypes")]
    [Authorize]
    public class TourTypesController : BaseApiController
    {
        ITourTypeProvider _tourTypeProvider;
        public TourTypesController(IErrorService errorService,
            ITourTypeProvider tourTypeProvider) : base(errorService)
        {
            _tourTypeProvider = tourTypeProvider;
        }

        [Route("getAll")]
        [HttpGet]
        //[Authorize(Roles = nameof(PermissionProvider.ViewProduct))]
        public HttpResponseMessage getAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _tourTypeProvider.GetAll();
                response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }
    }
}
