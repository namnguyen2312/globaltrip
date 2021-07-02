using NBT.Core.Domain.Blog;
using NBT.Core.Services.ApplicationServices.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Infra.Services.Blog
{
    public class BlogPostTypeProvider : IBlogPostTypeProvider
    {
        public static readonly BlogPostType Blog = new BlogPostType {Id = 1, Name = "Tin tức" };
        public static readonly BlogPostType ServiceSpecialBlog = new BlogPostType { Id = 2, Name = "Dịch vụ đặc biệt" };
        public static readonly BlogPostType EventSpecialBlog = new BlogPostType { Id = 3, Name = "Sự kiện đặc biệt" };
        public IEnumerable<BlogPostType> GetAll()
        {
            return new[]
            {
                Blog,
                ServiceSpecialBlog,
                EventSpecialBlog
            };
        }
    }
}
