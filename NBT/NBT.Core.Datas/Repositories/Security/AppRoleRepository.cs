using NBT.Core.Domain.Identity;
using NBT.Core.Services.DomainServices.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Datas.Repositories.Security
{
    public class AppRoleRepository : RepositoryBase<AppRole>, IAppRoleRepository
    {
        public AppRoleRepository(MasterDBContext dbContext) : base(dbContext)
        {
        }
        
        public IEnumerable<AppRole> GetListRoleByGroupId(int groupId)
        {
            var query = from g in DbContext.AppRoles.AsNoTracking()
                        join ug in DbContext.AppRoleGroups.AsNoTracking()
                        on g.Id equals ug.RoleId
                        where ug.GroupId == groupId
                        select g;
            return query;
        }
    }
}
