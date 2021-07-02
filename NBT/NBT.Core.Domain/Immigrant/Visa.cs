using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Domain.Immigrant
{
    public class Visa : BaseEntity<int>
    {
        [MaxLength(128)]
        public string Name { set; get; }
        [MaxLength(128)]
        public string Code { set; get; }
        public int DisplayOrder { set; get; } = -1;
        [MaxLength(256)]
        public string Alias { set; get; }
        [MaxLength(128)]
        public string ShortDescription { set; get; }
        public string FullDescription { set; get; }
        [MaxLength(512)]
        public string Image { set; get; }
        [MaxLength(128)]
        public string KeywordSeo { set; get; }
        [MaxLength(128)]
        public string TitleSeo { set; get; }
        [MaxLength(256)]
        public string DescriptionSeo { set; get; }
        public bool IsWeb { set; get; }
        public DateTimeOffset CreatedDate { set; get; }
        [MaxLength(256)]
        public string CreatedBy { set; get; }
    }
}
