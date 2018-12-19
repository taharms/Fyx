namespace Fyx.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;


    internal sealed class Configuration : DbMigrationsConfiguration<Fyx.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        public static List<IdentityRole> SeedDefaultRoles(ApplicationDbContext context)
        {
            var roles = new List<IdentityRole> {
                new IdentityRole("SiteAdmin"),
                new IdentityRole("CompanyAdmin"),
                new IdentityRole("Tech"),
                new IdentityRole("Caller"),
            };

            roles.ForEach(role => context.Roles.AddOrUpdate(r => r.Name, role));

            return roles;
        }

        protected override void Seed(Fyx.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var roles = SeedDefaultRoles(context);
        }
    }
}
