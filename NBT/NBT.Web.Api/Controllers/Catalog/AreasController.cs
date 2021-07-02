using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NBT.Core.Domain.Catalog;
using NBT.Core.Services.ApplicationServices.Catalog;
using NBT.Core.Services.ApplicationServices.System;

namespace NBT.Web.Api.Controllers.Catalog
{
    [RoutePrefix("api/areas")]
    [Authorize]
    public class AreasController : BaseApiController
    {
        IAreaService _areaService;
        public AreasController(IErrorService errorService,
            IAreaService areaService) : base(errorService)
        {
            _areaService = areaService;
        }

        [Route("getByid/{id:int}")]
        [HttpGet]
        //[Authorize(Roles = nameof(PermissionProvider.ViewGroup))]
        public HttpResponseMessage GetByid(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _areaService.GetById(id);
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
                var model = _areaService.GetAll();
                response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        //[Authorize(Roles = nameof(PermissionProvider.AddArea))]
        public HttpResponseMessage Create(HttpRequestMessage request, Area area)
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
                    _areaService.Add(area);

                    reponse = request.CreateResponse(HttpStatusCode.Created, area);
                }
                return reponse;

            });
        }
        [Route("Update")]
        [HttpPut]
        //[Authorize(Roles = nameof(PermissionProvider.AddArea))]
        public HttpResponseMessage Update(HttpRequestMessage request, Area area)
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
                        _areaService.Update(area);

                        reponse = request.CreateResponse(HttpStatusCode.OK, area);
                    }
                    return reponse;
               
            });
        }
    }
}
