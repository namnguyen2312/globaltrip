using NBT.Core.Domain.Blog;
using NBT.Core.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Services.DomainServices.Blog
{
    public interface IBlogPostRepository: IRepository<BlogPost>
    {
    }
}
