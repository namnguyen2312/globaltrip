using NBT.Core.Domain.Blog;
using NBT.Core.Services.ApplicationServices.Blog;
using NBT.Core.Services.Data;
using NBT.Core.Services.DomainServices.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Infra.Services.Blog
{
    public class BlogPostAboutService : ServiceBase<BlogPostAbout>, IBlogPostAboutService
    {
        IBlogPostAboutRepository _blogPostAboutRepo;
        public BlogPostAboutService(IUnitOfWork unitOfWork, IBlogPostAboutRepository blogPostAboutRepo) : base(unitOfWork, blogPostAboutRepo)
        {
            _blogPostAboutRepo = blogPostAboutRepo;
        }
    }
}
