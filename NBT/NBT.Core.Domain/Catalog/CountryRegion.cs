using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Domain.Catalog
{
    public class CountryRegion: BaseEntity<int>
    {
        [MaxLength(128)]
        public string Code { set; get; }
        [MaxLength(128)]
        public string Name { set; get; }
        public int ContinentId { set; get; }
        [MaxLength(512)]
        public string Image { set; get; }
        public bool IsShow { set; get; }
        public bool Domestic { set; get; }
    }
}
