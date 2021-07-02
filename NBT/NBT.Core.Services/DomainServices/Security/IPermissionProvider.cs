using NBT.Core.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Services.DomainServices.Security
{
    public interface IPermissionProvider
    {
        IEnumerable<AppRole> GetPermissions();
    }
}
