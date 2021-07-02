using NBT.Core.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Services.ApplicationServices.Security
{
    public interface IAppGroupService:IService<AppGroup>
    {
        AppGroup GetDetail(int id);

        IEnumerable<AppGroup> GetAll(int page, int pageSize, out int totalRow, string filter);

        IEnumerable<AppGroup> GetAll();

        AppGroup Insert(AppGroup appGroup);


        AppGroup Delete(int id);

        bool AddUserToGroups(IEnumerable<AppUserGroup> groups, string userId);

        IEnumerable<AppGroup> GetListGroupByUserId(string userId);

        IEnumerable<AppUser> GetListUserByGroupId(int groupId);
    }
}
