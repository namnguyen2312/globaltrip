using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Domain.System
{
    public class Settings : BaseEntity<int>
    {
        [MaxLength(128)]
        public string Name { set; get; }
        [MaxLength(512)]
        public string Value { set; get; }
    }
}
