using NBT.Core.Domain.Identity;
using NBT.Core.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Services.DomainServices.Security
{
    public interface IAppGroupRepository: IRepository<AppGroup>
    {
        IEnumerable<AppGroup> GetListGroupByUserId(string userId);
        IEnumerable<AppUser> GetListUserByGroupId(int groupId);
    }
}
