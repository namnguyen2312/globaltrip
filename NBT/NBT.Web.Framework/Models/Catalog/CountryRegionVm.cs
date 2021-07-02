using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBT.Web.Framework.Models.Catalog
{
    public class CountryRegionVm
    {
        public int Id { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public int ContinentId { set; get; }
        public string Image { set; get; }
        public bool IsShow { set; get; }
        public bool Domestic { set; get; }
    }
}