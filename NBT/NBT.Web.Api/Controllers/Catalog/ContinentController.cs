using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NBT.Core.Services.ApplicationServices.System;
using NBT.Core.Services.ApplicationServices.Catalog;
using NBT.Core.Domain.Catalog;
using NBT.Core.Common.Exceptions;

namespace NBT.Web.Api.Controllers.Catalog
{
    [RoutePrefix("api/continent")]
    [Authorize]
    public class ContinentController : BaseApiController
    {
        IContinentService _continentService;
        public ContinentController(IErrorService errorService
            , IContinentService continentService) : base(errorService)
        {
            _continentService = continentService;
        }

        [Route("getByid/{id:int}")]
        [HttpGet]
        //[Authorize(Roles = nameof(PermissionProvider.ViewGroup))]
        public HttpResponseMessage GetByid(HttpRequestMessage request,int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _continentService.GetById(id);
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
                var model = _continentService.GetAll();
                response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        //[Authorize(Roles = nameof(PermissionProvider.AddArea))]
        public HttpResponseMessage Create(HttpRequestMessage request, Continent continent)
        {
            return CreateHttpResponse(request, () =>
            {
                try
                {
                    HttpResponseMessage reponse = null;
                    if (!ModelState.IsValid)
                    {
                        reponse = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                    }
                    else
                    {
                        _continentService.Add(continent);

                        reponse = request.CreateResponse(HttpStatusCode.Created, continent);
                    }
                    return reponse;
                }
                catch (NameDuplicatedException dex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.Conflict, dex.Message);
                }
            });
        }
        [Route("Update")]
        [HttpPut]
        //[Authorize(Roles = nameof(PermissionProvider.AddArea))]
        public HttpResponseMessage Update(HttpRequestMessage request, Continent continent)
        {
            return CreateHttpResponse(request, () =>
            {
                try
                {
                    HttpResponseMessage reponse = null;
                    if (!ModelState.IsValid)
                    {
                        reponse = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                    }
                    else
                    {
                        _continentService.UpdateAsync(continent);

                        reponse = request.CreateResponse(HttpStatusCode.OK, continent);
                    }
                    return reponse;
                }
                catch (NameDuplicatedException dex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.Conflict, dex.Message);
                }
            });
        }
    }
}
