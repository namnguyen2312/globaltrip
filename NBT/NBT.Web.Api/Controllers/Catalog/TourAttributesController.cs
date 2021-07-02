using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NBT.Core.Services.ApplicationServices.System;
using NBT.Core.Services.ApplicationServices.Catalog;
using NBT.Core.Domain.Catalog;

namespace NBT.Web.Api.Controllers.Catalog
{
    [RoutePrefix("api/tourAttributes")]
    [Authorize]
    public class TourAttributesController : BaseApiController
    {
        ITourAttributeService _tourAttributeService;
        public TourAttributesController(IErrorService errorService
            , ITourAttributeService tourAttributeService) : base(errorService)
        {
            _tourAttributeService = tourAttributeService;
        }
        [Route("getByid/{id:int}")]
        [HttpGet]
        //[Authorize(Roles = nameof(PermissionProvider.ViewGroup))]
        public HttpResponseMessage GetByid(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _tourAttributeService.GetById(id);
                response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }

        [Route("getAll")]
        [HttpGet]
        //[Authorize(Roles = nameof(PermissionProvider.ViewGroup))]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _tourAttributeService.GetAll();
                response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        //[Authorize(Roles = nameof(PermissionProvider.AddArea))]
        public HttpResponseMessage Create(HttpRequestMessage request, TourAttribute tourAttribute)
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
                    _tourAttributeService.Add(tourAttribute);

                    reponse = request.CreateResponse(HttpStatusCode.Created, tourAttribute);
                }
                return reponse;

            });
        }
        [Route("Update")]
        [HttpPut]
        //[Authorize(Roles = nameof(PermissionProvider.AddArea))]
        public HttpResponseMessage Update(HttpRequestMessage request, TourAttribute tourAttribute)
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
                    _tourAttributeService.UpdateAsync(tourAttribute);

                    reponse = request.CreateResponse(HttpStatusCode.OK, tourAttribute);
                }
                return reponse;

            });
        }
    }

}
