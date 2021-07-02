using NBT.Core.Domain.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Services.ApplicationServices.Security
{
    public interface IAppUserService
    {
        IPagedList<AppUser> GetMultiPaging(int pageIndex = 1, int pageSize = 20, string filter = "", int userType = 0);
        IEnumerable<AppUser> GetMultiByIds(List<string> userIds);
        AppUser GetById(string Id);
    }
}
