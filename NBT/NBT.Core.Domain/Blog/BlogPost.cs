using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Domain.Blog
{
    public class BlogPost : BaseEntity<long>
    {
        [MaxLength(128)]
        public string Title { set; get; }
        public int BlogPostCategory { set; get; }
        public int BlogPostType { set; get; }
        [MaxLength(128)]
        public string Alias { set; get; }
        [MaxLength(128)]
        public string ShortContent { set; get; }
        public string FullContent { set; get; }
        [MaxLength(512)]
        public string Image { set; get; }
        [MaxLength(128)]
        public string KeywordSeo { set; get; }
        [MaxLength(128)]
        public string TitleSeo { set; get; }
        [MaxLength(256)]
        public string DescriptionSeo { set; get; }
        public string Tag { set; get; }
        public bool IsShow { set; get; }
        public bool IsHome { set; get; }
        public bool IsDel { set; get; }
        public DateTimeOffset? CreatedDate { set; get; }

        [MaxLength(256)]
        public string CreatedBy { set; get; }

        public DateTimeOffset? UpdatedDate { set; get; }

        [MaxLength(256)]
        public string UpdatedBy { set; get; }
    }
}
