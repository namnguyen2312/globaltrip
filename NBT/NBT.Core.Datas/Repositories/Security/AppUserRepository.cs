using NBT.Core.Domain.Identity;
using NBT.Core.Services.DomainServices.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Datas.Repositories.Security
{
    public class AppUserRepository : RepositoryBase<AppUser>, IAppUserRepository
    {
        public AppUserRepository(MasterDBContext dbContext) : base(dbContext)
        {
        }
    }
}
