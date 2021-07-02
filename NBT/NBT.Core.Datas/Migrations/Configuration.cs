namespace NBT.Core.Datas.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using NBT.Core.Domain.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<NBT.Core.Datas.MasterDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(NBT.Core.Datas.MasterDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            InitUser(context);
        }

        private void InitUser(MasterDBContext context)
        {
            var manager = new UserManager<AppUser>(new UserStore<AppUser>(new MasterDBContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new MasterDBContext()));
            if (manager.Users.Count() != 0)
                return;
            var user = new AppUser()
            {
                UserName = "admin",
                Email = "gtrip@gmail.com",
                EmailConfirmed = true,
                IsSystemAccount = true,
                IsActive = true

            };

            manager.Create(user, "123456");
        }
    }
}
