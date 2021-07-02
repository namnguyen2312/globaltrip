using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using NBT.Core.Common.Helper;
using NBT.Core.Domain.Blog;
using NBT.Core.Services.ApplicationServices.Blog;
using NBT.Core.Services.ApplicationServices.System;
using NBT.Web.Framework.Core;

namespace NBT.Web.Api.Controllers.Blog
{
    [RoutePrefix("api/blogPosts")]
    [Authorize]
    public class BlogPostController : BaseApiController
    {
        IBlogPostService _blogPostService;
        public BlogPostController(IErrorService errorService,
            IBlogPostService blogPostService) : base(errorService)
        {
            _blogPostService = blogPostService;
        }

        [Route("getAll")]
        [HttpGet]
        //[Authorize(Roles = nameof(PermissionProvider.ViewProduct))]
        public HttpResponseMessage getAll(HttpRequestMessage request,
            int page = 0, int pageSize = 20, string filter = "",int categoryId=0,int blogPostType=0)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _blogPostService.GetAll(page + 1, pageSize, filter,blogPostType: blogPostType);
                PaginationSet<BlogPost> pagedSet = new PaginationSet<BlogPost>()
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
                var model = _blogPostService.GetById(id);
                response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        //[Authorize(Roles = nameof(PermissionProvider.AddArea))]
        public HttpResponseMessage Create(HttpRequestMessage request, BlogPost blogPost)
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
                    blogPost.Alias = StringHelper.ToUrlFriendlyWithDateTime(blogPost.Title);
                    blogPost.CreatedDate = GetDateTimeNowUTC();
                    blogPost.CreatedBy = User.Identity.GetUserId();
                    _blogPostService.Add(blogPost);
                    reponse = request.CreateResponse(HttpStatusCode.Created, blogPost);
                }
                return reponse;

            });
        }

        [Route("update")]
        [HttpPut]
        //[Authorize(Roles = nameof(PermissionProvider.AddArea))]
        public HttpResponseMessage Update(HttpRequestMessage request, BlogPost blogPost)
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
                    blogPost.UpdatedDate = GetDateTimeNowUTC();
                    blogPost.UpdatedBy = User.Identity.GetUserId();
                    blogPost.Alias = StringHelper.ToUrlFriendlyWithDateTime(blogPost.Title, blogPost.CreatedDate.Value.DateTime);
                    _blogPostService.Update(blogPost);
                    reponse = request.CreateResponse(HttpStatusCode.Created, blogPost);
                }
                return reponse;

            });
        }

        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, long id)
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
                    var model = _blogPostService.GetById(id);
                    _blogPostService.DeleteAsync(model);
                    var result = true;
                    response = request.CreateResponse(HttpStatusCode.Created, result);
                }

                return response;
            });
        }
    }
}
