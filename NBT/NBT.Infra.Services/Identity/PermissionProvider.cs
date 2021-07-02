using NBT.Core.Services.DomainServices.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBT.Core.Domain.Identity;

namespace NBT.Infra.Services.Identity
{
    public class PermissionProvider : IPermissionProvider
    {
        public static readonly string ViewPermission;

        public static readonly string ViewUser;
        public static readonly string AddUser;
        public static readonly string EditUser;
        public static readonly string DelUser;

        public static readonly string Settings;
        public static readonly string ManageGroup;

        public static readonly AppRole ViewPermissionRecord = new AppRole { Name = nameof(ViewPermission), Description = "Xem quyền" };

        public static readonly AppRole ViewUserRecord = new AppRole { Name = nameof(ViewUser), Description = "Xem user" };
        public static readonly AppRole AddUserRecord = new AppRole { Name = nameof(AddUser), Description = "Thêm user" };
        public static readonly AppRole EditUserRecord = new AppRole { Name = nameof(EditUser), Description = "Chỉnh sửa user" };
        public static readonly AppRole DelUserRecord = new AppRole { Name = nameof(DelUser), Description = "Xóa user" };

        public static readonly AppRole ManageGroupRecord = new AppRole { Name = nameof(ManageGroup), Description = "Quản lý nhóm quyền" };

        public static readonly AppRole SettingsRecord = new AppRole { Name = nameof(Settings), Description = "Cấu hình website" };
        public IEnumerable<AppRole> GetPermissions()
        {
            return new[]
            {
                ViewPermissionRecord,

                ViewUserRecord,
                AddUserRecord,
                EditUserRecord,
                DelUserRecord,

                ManageGroupRecord,
                SettingsRecord
            };
        }
    }
}
