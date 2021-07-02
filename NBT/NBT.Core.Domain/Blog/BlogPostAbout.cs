using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Domain.Blog
{
    public class BlogPostAbout:BaseEntity<int>
    {
        [MaxLength(128)]
        public string Title { set; get; }
        [MaxLength(64)]
        public string Code { set; get; }
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
        public bool IsShow { set; get; }
        public bool IsHot { set; get; }
        public bool IsDel { set; get; }
        public DateTimeOffset? CreatedDate { set; get; }

        [MaxLength(256)]
        public string CreatedBy { set; get; }

        public DateTimeOffset? UpdatedDate { set; get; }

        [MaxLength(256)]
        public string UpdatedBy { set; get; }
    }
}
