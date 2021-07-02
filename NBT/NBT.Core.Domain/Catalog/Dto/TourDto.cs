using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Domain.Catalog.Dto
{
    public class TourDto
    {
        public long Id { set; get; }
        [MaxLength(128)]
        public string Name { set; get; }
        public string EventTitle { set; get; }
        public int TourType { set; get; }
        public decimal Price { set; get; }
        [MaxLength(128)]
        public string Alias { set; get; }
        [MaxLength(128)]
        public string Code { set; get; }
        public int CountryRegionId { set; get; }
        public int StateProvinceId { set; get; }
        public int AreaId { set; get; }
        public int DisplayOrder { set; get; }
        [MaxLength(128)]
        public string ShortDescription { set; get; }
        public string FullDescription { set; get; }
        [MaxLength(512)]
        public string Image { set; get; }
        [MaxLength(512)]
        public string LargeImage { set; get; }
        [MaxLength(128)]
        public string KeywordSeo { set; get; }
        [MaxLength(128)]
        public string TitleSeo { set; get; }
        [MaxLength(256)]
        public string DescriptionSeo { set; get; }
        public int TotalDays { set; get; }
        [MaxLength(256)]
        public string DayBegin { set; get; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset FromDate { set; get; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset ToDate { set; get; }
        public bool IsShow { set; get; }
        public bool IsHot { set; get; }
        public bool IsDel { set; get; }
        public DateTimeOffset? CreatedDate { set; get; }

        [MaxLength(256)]
        public string CreatedBy { set; get; }

        public DateTimeOffset? UpdatedDate { set; get; }

        [MaxLength(256)]
        public string UpdatedBy { set; get; }
        public string CountryRegionName { set; get; }
        public string StateProvinceName { set; get; }
        public List<TourAttributeValueDto> TourAttr { set; get; }
    }
}
