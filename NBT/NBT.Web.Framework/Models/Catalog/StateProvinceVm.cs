using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBT.Web.Framework.Models.Catalog
{
    public class StateProvinceVm
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Code { set; get; }
        public int AreaId { set; get; }
        public int CountryRegionId { set; get; }
        public bool IsShow { set; get; }
        public string Image { set; get; }
        public DateTimeOffset? CreatedDate { set; get; }
        public string CreatedBy { set; get; }
        public DateTimeOffset? UpdatedDate { set; get; }
        public string UpdatedBy { set; get; }
    }
}