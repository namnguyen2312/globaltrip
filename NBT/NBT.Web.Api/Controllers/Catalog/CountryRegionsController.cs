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

namespace NBT.Web.Api.Controllers.Catalog
{
    [RoutePrefix("api/countryRegion")]
    [Authorize]
    public class CountryRegionsController : BaseApiController
    {
        ICountryRegionService _countryRegionService;
        public CountryRegionsController(IErrorService errorService
            , ICountryRegionService countryRegionService) : base(errorService)
        {
            _countryRegionService = countryRegionService;
        }

        [Route("getAll")]
        [HttpGet]
        //[Authorize(Roles = nameof(PermissionProvider.ViewProduct))]
        public HttpResponseMessage getAll(HttpRequestMessage request,
            int page=0, int pageSize=20, string filter = "", int continentId = 0)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _countryRegionService.GetAll(page + 1, pageSize, filter, continentId);
                PaginationSet<CountryRegion> pagedSet = new PaginationSet<CountryRegion>()
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
        public HttpResponseMessage getAllNoPaging(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _countryRegionService.GetAll(null);
                
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
                var model = _countryRegionService.GetById(id);
                response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        //[Authorize(Roles = nameof(PermissionProvider.AddArea))]
        public HttpResponseMessage Create(HttpRequestMessage request, CountryRegion countryRegion)
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
                        _countryRegionService.Add(countryRegion);

                        reponse = request.CreateResponse(HttpStatusCode.Created, countryRegion);
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
        public HttpResponseMessage Update(HttpRequestMessage request, CountryRegion countryRegion)
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
                        _countryRegionService.UpdateAsync(countryRegion);

                        reponse = request.CreateResponse(HttpStatusCode.OK, countryRegion);
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
