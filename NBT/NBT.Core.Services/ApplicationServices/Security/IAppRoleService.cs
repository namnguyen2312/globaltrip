using NBT.Core.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Services.ApplicationServices.Security
{
    public interface IAppRoleService
    {
        AppRole GetDetail(string id);

        IEnumerable<AppRole> GetAll(int page, int pageSize, out int totalRow, string filter);

        IEnumerable<AppRole> GetAll();

        AppRole Insert(AppRole appRole);

        void InsertRoleFromSystem();

        //void Update(AppRole AppRole);

        void Delete(string id);

        //Add roles to a sepcify group
        bool AddRolesToGroup(IEnumerable<AppRoleGroup> roleGroups, int groupId);

        //Get list role by group id
        IEnumerable<AppRole> GetListRoleByGroupId(int groupId);
    }
}
