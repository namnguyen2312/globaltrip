using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Domain.System
{
    public class Converse : BaseEntity<int>
    {
        [MaxLength(128)]
        public string TypeConverse { set; get; }
        [MaxLength(256)]
        public string NickName { set; get; }
        [MaxLength(256)]
        public string Phone { set; get; }
        [MaxLength(256)]
        public string FullName { set; get; }
        [MaxLength(256)]
        public string Email { set; get; }
        public bool IsShow { set; get; }

    }
}
