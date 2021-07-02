using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using NBT.Core.Common.Helper;
using NBT.Core.Domain.Immigrant;
using NBT.Core.Services.ApplicationServices.Immigrant;
using NBT.Core.Services.ApplicationServices.System;
using NBT.Web.Framework.Core;

namespace NBT.Web.Api.Controllers.Immigrant
{
    [RoutePrefix("api/visas")]
    [Authorize]
    public class VisaController : BaseApiController
    {
        IVisaService _visaService;
        public VisaController(IErrorService errorService
            , IVisaService visaService) : base(errorService)
        {
            _visaService = visaService;
        }

        [Route("getAll")]
        [HttpGet]
        //[Authorize(Roles = nameof(PermissionProvider.ViewProduct))]
        public HttpResponseMessage getAll(HttpRequestMessage request,
            int page = 0, int pageSize = 20, string filter = "")
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _visaService.GetAll(page + 1, pageSize, filter);
                PaginationSet<Visa> pagedSet = new PaginationSet<Visa>()
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

        [Route("getByid/{id:int}")]
        [HttpGet]
        //[Authorize(Roles = nameof(PermissionProvider.ViewGroup))]
        public HttpResponseMessage GetByid(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _visaService.GetById(id);
                response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        //[Authorize(Roles = nameof(PermissionProvider.AddArea))]
        public HttpResponseMessage Create(HttpRequestMessage request, Visa visa)
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
                    visa.Alias = StringHelper.ToUrlFriendlyWithDateTime(visa.Name);
                    visa.CreatedDate = GetDateTimeNowUTC();
                    visa.CreatedBy = User.Identity.GetUserId();
                    visa.Alias = StringHelper.ToUrlFriendlyWithDateTime(visa.Name,visa.CreatedDate.DateTime);
                    _visaService.Add(visa);
                    reponse = request.CreateResponse(HttpStatusCode.Created, visa);
                }
                return reponse;

            });
        }

        [Route("update")]
        [HttpPut]
        //[Authorize(Roles = nameof(PermissionProvider.AddArea))]
        public HttpResponseMessage Update(HttpRequestMessage request, Visa visa)
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
                    visa.Alias = StringHelper.ToUrlFriendlyWithDateTime(visa.Name, visa.CreatedDate.DateTime);
                    _visaService.Update(visa);
                    reponse = request.CreateResponse(HttpStatusCode.Created, visa);
                }
                return reponse;

            });
        }
    }
}
