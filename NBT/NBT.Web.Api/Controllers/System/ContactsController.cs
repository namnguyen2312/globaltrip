using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NBT.Core.Domain.System;
using NBT.Core.Services.ApplicationServices.System;

namespace NBT.Web.Api.Controllers.System
{
    [RoutePrefix("api/contacts")]
    [Authorize]
    public class ContactsController : BaseApiController
    {
        IConverseService _converseService;
        public ContactsController(IErrorService errorService
            , IConverseService converseService) : base(errorService)
        {
            _converseService = converseService;
        }

        [Route("getByid/{id:int}")]
        [HttpGet]
        //[Authorize(Roles = nameof(PermissionProvider.ViewGroup))]
        public HttpResponseMessage GetByid(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _converseService.GetById(id);
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
                var model = _converseService.GetAll();
                response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        //[Authorize(Roles = nameof(PermissionProvider.AddArea))]
        public HttpResponseMessage Create(HttpRequestMessage request, Converse converse)
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
                    _converseService.Add(converse);

                    reponse = request.CreateResponse(HttpStatusCode.Created, converse);
                }
                return reponse;

            });
        }
        [Route("Update")]
        [HttpPut]
        //[Authorize(Roles = nameof(PermissionProvider.AddArea))]
        public HttpResponseMessage Update(HttpRequestMessage request, Converse converse)
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
                    _converseService.Update(converse);

                    reponse = request.CreateResponse(HttpStatusCode.OK, converse);
                }
                return reponse;

            });
        }

        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var model = _converseService.GetById(id);
                    _converseService.DeleteAsync(model);
                    var result = true;
                    response = request.CreateResponse(HttpStatusCode.Created, result);
                }

                return response;
            });
        }
    }
}
