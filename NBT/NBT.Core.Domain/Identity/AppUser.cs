using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Domain.Identity
{
    public class AppUser: IdentityUser
    {
        [MaxLength(256)]
        public string FullName { set; get; }
        [MaxLength(256)]
        public string Address { set; get; }
        public DateTimeOffset BirthDay { set; get; }
        public int UserType { set; get; }
        public bool Gender { set; get; }
        public bool IsActive { set; get; }
        public bool IsSystemAccount { set; get; }
        public DateTimeOffset CreatedDate { set; get; }
        public DateTimeOffset UpdatedDate { set; get; }
        [MaxLength(64)]
        public string CreatedBy { set; get; }
        [MaxLength(64)]
        public string UpdatedBy { set; get; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
