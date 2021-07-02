using NBT.Core.Domain.Identity;
using NBT.Core.Services.ApplicationServices.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBT.Core.Services.Data;
using NBT.Core.Services.DomainServices.Security;
using NBT.Core.Common.Exceptions;

namespace NBT.Infra.Services.Security
{
    public class AppRoleService : ServiceBase<AppRole>, IAppRoleService
    {
        IAppRoleRepository _appRoleRepo;
        IAppRoleGroupRepository _appRoleGroupRepo;
        IPermissionProvider _permissionProvider;
        public AppRoleService(IUnitOfWork unitOfWork
            , IAppRoleRepository appRoleRepo
            , IAppRoleGroupRepository appRoleGroupRepo
            , IPermissionProvider permissionProvider) : base(unitOfWork, appRoleRepo)
        {
            _appRoleRepo = appRoleRepo;
            _appRoleGroupRepo = appRoleGroupRepo;
            _permissionProvider = permissionProvider;
        }

        public bool AddRolesToGroup(IEnumerable<AppRoleGroup> roleGroups, int groupId)
        {
            var modelAppRoleGroup = _appRoleGroupRepo.Table.Where(x=>x.GroupId == groupId).ToList();
            _appRoleGroupRepo.Delete(modelAppRoleGroup);
            //_appRoleGroupRepo.DeleteMulti(x => x.GroupId == groupId);
            foreach (var roleGroup in roleGroups)
            {
                _appRoleGroupRepo.Insert(roleGroup);
            }
            return true;
        }

        public void Delete(string id)
        {
            var modelAppRole = _appRoleRepo.TableNoTracking.Where(x => x.Id == id);
            _appRoleRepo.DeleteAsync(modelAppRole);
            //_appRoleRepository.DeleteMulti(x => x.Id == id);
        }

        public IEnumerable<AppRole> GetAll(int page, int pageSize, out int totalRow, string filter)
        {
            var query = _appRoleRepo.TableNoTracking;
            if (!string.IsNullOrEmpty(filter))
                query = query.Where(x => x.Description.Contains(filter));

            totalRow = query.Count();
            return query.OrderBy(x => x.Description).Skip(page * pageSize).Take(pageSize);
        }

        public IEnumerable<AppRole> GetAll()
        {
            return _appRoleRepo.TableNoTracking.ToList();
        }

        public AppRole GetDetail(string id)
        {
            return _appRoleRepo.TableNoTracking.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<AppRole> GetListRoleByGroupId(int groupId)
        {
            return _appRoleRepo.GetListRoleByGroupId(groupId).ToList();
        }

        public AppRole Insert(AppRole appRole)
        {
            if (_appRoleRepo.CheckContains(x => x.Name == appRole.Name))
                throw new NameDuplicatedException("Tên không được trùng");
            return _appRoleRepo.Insert(appRole);
        }

        public void InsertRoleFromSystem()
        {
            var permissionDefault = _permissionProvider.GetPermissions();
            var modelRole = _appRoleRepo.TableNoTracking.ToList();

            permissionDefault = permissionDefault.Where(x => !modelRole.Select(b => b.Name).Contains(x.Name));
            if(permissionDefault.Count()>0)
            {
                var appRoles = new List<AppRole>();
                foreach (var item in permissionDefault)
                {
                    var newAppRole = new AppRole();
                    newAppRole.Id = Guid.NewGuid().ToString();
                    newAppRole.Name = item.Name;
                    newAppRole.Description = item.Description;
                    appRoles.Add(newAppRole);
                }
                _appRoleRepo.Insert(appRoles);
            }

        }

        public override AppRole Update(AppRole AppRole)
        {
            if (_appRoleRepo.CheckContains(x => x.Description == AppRole.Description && x.Id != AppRole.Id))
                throw new NameDuplicatedException("Tên không được trùng");
            return _appRoleRepo.Update(AppRole);
        }
    }
}
