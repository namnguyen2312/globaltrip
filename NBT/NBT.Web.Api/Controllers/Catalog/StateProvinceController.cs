using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NBT.Core.Services.ApplicationServices.System;
using NBT.Core.Services.ApplicationServices.Catalog;
using NBT.Web.Framework.Core;
using NBT.Core.Domain.Catalog;
using NBT.Core.Common.Exceptions;
using Microsoft.AspNet.Identity;

namespace NBT.Web.Api.Controllers.Catalog
{
    [RoutePrefix("api/stateProvince")]
    [Authorize]
    public class StateProvinceController : BaseApiController
    {
        IStateProvinceService _stateProvinceService;
        public StateProvinceController(IErrorService errorService
            , IStateProvinceService stateProvinceService) : base(errorService)
        {
            _stateProvinceService = stateProvinceService;
        }

        [Route("getAll")]
        [HttpGet]
        //[Authorize(Roles = nameof(PermissionProvider.ViewProduct))]
        public HttpResponseMessage getAll(HttpRequestMessage request,
            int page = 0, int pageSize = 20, string filter = "", int countryRegionId = 0)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _stateProvinceService.GetAll(page + 1, pageSize, filter, countryRegionId);
                PaginationSet<StateProvince> pagedSet = new PaginationSet<StateProvince>()
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

        [Route("getAllNoPaging")]
        [HttpGet]
        //[Authorize(Roles = nameof(PermissionProvider.ViewProduct))]
        public HttpResponseMessage GetAllNoPaging(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _stateProvinceService.GetAll(null);
               
                response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }

        [Route("getByid/{id:int}")]
        [HttpGet]
        //[Authorize(Roles = nameof(PermissionProvider.ViewGroup))]
        public HttpResponseMessage GetByid(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _stateProvinceService.GetById(id);
                response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        //[Authorize(Roles = nameof(PermissionProvider.AddArea))]
        public HttpResponseMessage Create(HttpRequestMessage request, StateProvince stateProvince)
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
                        stateProvince.CreatedBy = User.Identity.GetUserId();
                        stateProvince.CreatedDate = GetDateTimeNowUTC();

                        _stateProvinceService.Add(stateProvince);

                        reponse = request.CreateResponse(HttpStatusCode.Created, stateProvince);
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
        public HttpResponseMessage Update(HttpRequestMessage request, StateProvince stateProvince)
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
                        stateProvince.UpdatedBy = User.Identity.GetUserId();
                        stateProvince.UpdatedDate = GetDateTimeNowUTC();
                        _stateProvinceService.UpdateAsync(stateProvince);

                        reponse = request.CreateResponse(HttpStatusCode.OK, stateProvince);
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
