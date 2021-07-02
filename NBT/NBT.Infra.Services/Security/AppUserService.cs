using NBT.Core.Domain.Identity;
using NBT.Core.Services.ApplicationServices.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBT.Core.Services.Data;
using NBT.Core.Services.DomainServices.Security;
using PagedList;

namespace NBT.Infra.Services.Security
{
    public class AppUserService : ServiceBase<AppUser>, IAppUserService
    {
        IAppUserRepository _appUserRepo;
        public AppUserService(IUnitOfWork unitOfWork, IAppUserRepository appUserRepo) : base(unitOfWork, appUserRepo)
        {
            _appUserRepo = appUserRepo;
        }

        public AppUser GetById(string Id)
        {
            return _appUserRepo.TableNoTracking.FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<AppUser> GetMultiByIds(List<string> userIds)
        {
            return _appUserRepo.TableNoTracking.Where(x => userIds.Contains(x.Id)).ToList();
        }

        public IPagedList<AppUser> GetMultiPaging(int pageIndex = 1, int pageSize = 20, string filter = "", int userType = 0)
        {
            var query = _appUserRepo.TableNoTracking;
            if (!string.IsNullOrEmpty(filter))
                query = query.Where(x => x.FullName.Contains(filter)
                || x.UserName.Contains(filter));
            query = query.OrderBy(x => x.UserName);
            return query.ToPagedList(pageIndex, pageSize);
        }

    }
}
