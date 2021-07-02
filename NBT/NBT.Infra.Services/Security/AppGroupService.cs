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
    public class AppGroupService : ServiceBase<AppGroup>, IAppGroupService
    {
        IAppGroupRepository _appGroupRepo;
        IAppUserGroupRepository _appUserGroupRepository;
        IUnitOfWork _uow;
        public AppGroupService(IUnitOfWork unitOfWork
            , IAppGroupRepository appGroupRepo
            , IAppUserGroupRepository appUserGroupRepository) : base(unitOfWork, appGroupRepo)
        {
            _appGroupRepo = appGroupRepo;
            _appUserGroupRepository = appUserGroupRepository;
            _uow = unitOfWork;
        }

        public bool AddUserToGroups(IEnumerable<AppUserGroup> groups, string userId)
        {
            var modelAppUserGroup = _appUserGroupRepository.Table.Where(x => x.UserId == userId);
            _appUserGroupRepository.DeleteAsync(modelAppUserGroup);
            foreach (var userGroup in groups)
            {
                _appUserGroupRepository.Insert(userGroup);
            }
            return true;
        }

        public AppGroup Delete(int id)
        {
            var appGroup = this._appGroupRepo.Table.FirstOrDefault(x => x.Id == id);
            return _appGroupRepo.Delete(appGroup);
        }

        public IEnumerable<AppGroup> GetAll(int page, int pageSize, out int totalRow, string filter)
        {
            var query = _appGroupRepo.TableNoTracking;
            if (!string.IsNullOrEmpty(filter))
                query = query.Where(x => x.Name.Contains(filter));

            totalRow = query.Count();
            return query.OrderBy(x => x.Name).Skip(page * pageSize).Take(pageSize);
        }

        public IEnumerable<AppGroup> GetAll()
        {
            return _appGroupRepo.TableNoTracking.ToList();
        }

        public AppGroup GetDetail(int id)
        {
            return _appGroupRepo.TableNoTracking.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<AppGroup> GetListGroupByUserId(string userId)
        {
            return _appGroupRepo.GetListGroupByUserId(userId).ToList();
        }

        public IEnumerable<AppUser> GetListUserByGroupId(int groupId)
        {
            return _appGroupRepo.GetListUserByGroupId(groupId).ToList();
        }

        public AppGroup Insert(AppGroup appGroup)
        {
            if (_appGroupRepo.CheckContains(x => x.Name == appGroup.Name))
                throw new NameDuplicatedException("Tên không được trùng");
            return _appGroupRepo.Insert(appGroup);
        }

        public override AppGroup Update(AppGroup appGroup)
        {
            if (_appGroupRepo.CheckContains(x => x.Name == appGroup.Name && x.Id != appGroup.Id))
                throw new NameDuplicatedException("Tên không được trùng");
            return _appGroupRepo.Update(appGroup);
        }
    }
}
