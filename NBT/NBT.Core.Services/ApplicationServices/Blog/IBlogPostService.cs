using NBT.Core.Domain.Blog;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Services.ApplicationServices.Blog
{
    public interface IBlogPostService:IService<BlogPost>
    {
        IPagedList<BlogPost> GetAll(int pageIndex = 1, int pageSize = 20, string filter = "", bool? isShow = null,int blogPostType =0);
        BlogPost GetByAlias(string alias);
        IEnumerable<BlogPost> GetAllHomeTop(int top=1, bool? isHome = null,int blogPostType = 0);
    }
}
