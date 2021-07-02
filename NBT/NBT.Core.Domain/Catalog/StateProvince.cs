using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Domain.Catalog
{
    public class StateProvince:BaseEntity<int>
    {
        [MaxLength(128)]
        public string Name { set; get; }
        [MaxLength(128)]
        public string Code { set; get; }
        public int CountryRegionId { set; get; }
        public int AreaId { set; get; }
        public bool IsShow { set; get; }
        [MaxLength(512)]
        public string Image { set; get; }
        public DateTimeOffset? CreatedDate { set; get; }

        [MaxLength(256)]
        public string CreatedBy { set; get; }

        public DateTimeOffset? UpdatedDate { set; get; }

        [MaxLength(256)]
        public string UpdatedBy { set; get; }
    }
}
