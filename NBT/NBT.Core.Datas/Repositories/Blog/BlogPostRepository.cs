using NBT.Core.Domain.Blog;
using NBT.Core.Services.DomainServices.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Datas.Repositories.Blog
{
    public class BlogPostRepository : RepositoryBase<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(MasterDBContext dbContext) : base(dbContext)
        {
        }
    }
}
