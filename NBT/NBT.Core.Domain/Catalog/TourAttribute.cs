using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Domain.Catalog
{
    public class TourAttribute:BaseEntity<int>
    {
        [MaxLength(128)]
        public string Name { set; get; }
    }
}
