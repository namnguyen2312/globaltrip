using Microsoft.AspNet.Identity.EntityFramework;
using NBT.Core.Datas;
using NBT.Core.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Infra.Services.Identity
{
    public class ApplicationUserStore : UserStore<AppUser>
    {
        public ApplicationUserStore(MasterDBContext context)
            : base(context)
        {

        }
    }
}
