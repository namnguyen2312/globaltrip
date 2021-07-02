using NBT.Core.Common;
using NBT.Core.Domain.Blog;
using NBT.Core.Services.ApplicationServices.Blog;
using NBT.Infra.Services.Blog;
using NBT.Web.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NBT.Web.Controllers
{
    public class BlogController : BaseController
    {
        IBlogPostService _blogPostService;
        public BlogController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }
        // GET: Blog
        public ActionResult Index(int pageIndex = 1, int pageSize = 12, string filter = "")
        {

            var model = _blogPostService.GetAll(pageIndex, pageSize, filter = "", true);

            PaginationSet<BlogPost> pagedSet = new PaginationSet<BlogPost>()
            {
                Page = pageIndex,
                TotalCount = model.TotalItemCount,
                TotalPages = (int)Math.Ceiling((decimal)model.TotalItemCount / pageSize),
                Items = model
            };
            this.LoadDefaultMetaSEO();
            return View(pagedSet);
        }

        public ActionResult Detail(string alias)
        {
            var model = _blogPostService.GetByAlias(alias);
            return View(model);
        }

        [ChildActionOnly]
        [OutputCache(Duration = SystemConstants.Hour)]
        public ActionResult BlogPostNews()
        {
            var model = _blogPostService.GetAllHomeTop(3,blogPostType: BlogPostTypeProvider.Blog.Id);
            return PartialView(model);
        }

        [ChildActionOnly]
        [OutputCache(Duration = SystemConstants.Hour)]
        public ActionResult HomeBlog()
        {
            var model = _blogPostService.GetAllHomeTop(3, true, blogPostType: BlogPostTypeProvider.Blog.Id);
            return PartialView(model);
        }

        [ChildActionOnly]
        [OutputCache(Duration = SystemConstants.Hour)]
        public ActionResult ServicesSpecial()
        {
            var model = _blogPostService.GetAllHomeTop(5, blogPostType: BlogPostTypeProvider.ServiceSpecialBlog.Id);
            return PartialView(model);
        }

        [ChildActionOnly]
        [OutputCache(Duration = SystemConstants.Hour)]
        public ActionResult EventSpecial()
        {
            var model = _blogPostService.GetAllHomeTop(10, blogPostType: BlogPostTypeProvider.EventSpecialBlog.Id);
            return PartialView(model);
        }
    }
}