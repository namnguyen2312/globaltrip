using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Domain.Blog
{
    public class BlogPostTag:BaseEntity<long>
    {
        public string SlugName { set; get; }
        public long BlogPostId { set; get; }
    }
}
