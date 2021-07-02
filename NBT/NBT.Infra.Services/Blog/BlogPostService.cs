using NBT.Core.Domain.Blog;
using NBT.Core.Services.ApplicationServices.Blog;
using NBT.Core.Services.Data;
using NBT.Core.Services.DomainServices.Blog;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Infra.Services.Blog
{
    public class BlogPostService : ServiceBase<BlogPost>, IBlogPostService
    {
        IBlogPostRepository _blogPostRepo;
        public BlogPostService(IUnitOfWork unitOfWork, IBlogPostRepository blogPostRepo) : base(unitOfWork, blogPostRepo)
        {
            _blogPostRepo = blogPostRepo;
        }

        public IPagedList<BlogPost> GetAll(int pageIndex = 1, int pageSize = 20, string filter = "", bool? isShow = null, int blogPostType = 0)
        {
            var query = _blogPostRepo.TableNoTracking.Where(x => x.IsDel == false);

            if (blogPostType != 0)
                query = query.Where(x => x.BlogPostType == blogPostType);
            if (!string.IsNullOrWhiteSpace(filter))
                query = query.Where(x => x.Title.Contains(filter));
            if (isShow != null)
                query = query.Where(x => x.IsShow == isShow.Value);

            return query.OrderByDescending(x => x.CreatedDate).ToPagedList(pageIndex, pageSize);
        }

        public IEnumerable<BlogPost> GetAllHomeTop(int top = 1, bool? isHome = null, int blogPostType = 0)
        {
            var query = _blogPostRepo.TableNoTracking.Where(x => x.IsDel == false && x.IsShow == true);
            if (isHome != null)
                query = query.Where(x => x.IsHome == isHome.Value);
            if (blogPostType != 0)
                query = query.Where(x => x.BlogPostType == blogPostType);

            return query.OrderBy(x => x.Title).ThenByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        public BlogPost GetByAlias(string alias)
        {
            return _blogPostRepo.GetMulti(x => x.Alias == alias).FirstOrDefault();
        }
    }
}
