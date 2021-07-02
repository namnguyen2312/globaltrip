using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NBT.Core.Services.ApplicationServices.Blog;
using NBT.Core.Services.ApplicationServices.System;

namespace NBT.Web.Api.Controllers.Blog
{
    [RoutePrefix("api/blogPostTypes")]
    [Authorize]
    public class BlogPostTypesController : BaseApiController
    {
        IBlogPostTypeProvider _blogPostTypeProvider;
        public BlogPostTypesController(IErrorService errorService,
            IBlogPostTypeProvider blogPostTypeProvider) : base(errorService)
        {
            _blogPostTypeProvider = blogPostTypeProvider;
        }

        [Route("getAll")]
        [HttpGet]
        //[Authorize(Roles = nameof(PermissionProvider.ViewProduct))]
        public HttpResponseMessage getAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _blogPostTypeProvider.GetAll();
                response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }
    }
}
