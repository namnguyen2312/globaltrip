using Microsoft.AspNet.Identity.EntityFramework;
using NBT.Core.Datas.Extensions;
using NBT.Core.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using NBT.Core.Domain.Catalog;
using NBT.Core.Domain.Immigrant;
using NBT.Core.Domain.Blog;
using NBT.Core.Domain.Orders;
using NBT.Core.Domain.System;

namespace NBT.Core.Datas
{
    public class MasterDBContext : IdentityDbContext<AppUser>, IDBContextExtension
    {
        public MasterDBContext() : base("MasterDBConnection")
        {

        }

        public DbSet<Continent> Continents { set; get; }
        public DbSet<CountryRegion> CountryRegions { set; get; }
        public DbSet<StateProvince> StateProvinces { set; get; }
        public DbSet<Area> Areas { set; get; }
        public DbSet<Tour> Tours { set; get; }
        public DbSet<TourAttribute> TourAttributes { set; get; }
        public DbSet<TourAttributeValue> TourAttributeValues { set; get; }
        public DbSet<Visa> Visas { set; get; }
        public DbSet<BlogPostAbout> BlogPostAbouts{ set;get;}
        public DbSet<BlogPost> BlogPosts { set; get; }
        public DbSet<BlogPostTag> BlogPostTags { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderItem> OrderItems { set; get; }
        public DbSet<Settings> Settings { set; get; }
        public DbSet<Converse> Converses { set; get; }

        //Identity///////////////////////////////////////////////////////////////////////////////////
        public DbSet<AppUserGroup> AppUserGroups { set; get; }
        public DbSet<AppRoleGroup> AppRoleGroups { set; get; }
        public DbSet<AppRole> AppRoles { set; get; }
        public DbSet<AppGroup> AppGroups { set; get; }


        public static MasterDBContext Create()
        {
            return new MasterDBContext();
        }
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasKey<string>(r => r.Id).ToTable("AppRoles");
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("AppUserRoles");
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("AppUserLogins");
            builder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable("AppUserClaims");
        }
        IDbSet<TEntity> IDBContextExtension.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }
    }
}
