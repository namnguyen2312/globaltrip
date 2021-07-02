using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NBT.Core.Domain.System;
using NBT.Core.Services.ApplicationServices.System;
using NBT.Infra.Services.Identity;

namespace NBT.Web.Api.Controllers.System
{
    [RoutePrefix("api/settings")]
    [Authorize]
    public class SettingsController : BaseApiController
    {
        ISettingsService _settingsService;
        public SettingsController(IErrorService errorService,
            ISettingsService settingsService) : base(errorService)
        {
            _settingsService = settingsService;
        }

        [Route("getAll")]
        [HttpGet]
        [Authorize(Roles = nameof(PermissionProvider.Settings))]
        public HttpResponseMessage getAll(HttpRequestMessage request,
            int page = 0, int pageSize = 20, string filter = "")
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                _settingsService.InsertFromSystem();
                var model = _settingsService.GetAll();
               
                response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [Authorize(Roles = nameof(PermissionProvider.Settings))]
        public HttpResponseMessage Update(HttpRequestMessage request, List<Settings> settings)
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
                    foreach (var item in settings)
                    {
                        _settingsService.Update(item);
                    }
                    var msg = "Đã lưu";
                    reponse = request.CreateResponse(HttpStatusCode.Created, msg);
                }
                return reponse;

            });
        }
    }
}
