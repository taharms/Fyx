using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fyx.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            LockoutEnabled = true;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("OrganizationId", OrganizationId.ToString()));

            return userIdentity;
        }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Street Address")]
        public String StreetAddress { get; set; }

        public String City { get; set; }

        public String State { get; set; }

        public String Country { get; set; }

        public String Zip { get; set; }

        public String Phone { get; set; }

        public Guid? OrganizationId { get; set; }

        [ForeignKey("OrganizationId")]
        public virtual Organization Organization { get; set; }

    }

    public class IdentityUserRoleComparer : IEqualityComparer<IdentityUserRole>
    {
        public bool Equals(IdentityUserRole x, IdentityUserRole y)
        {
            return x.RoleId == y.RoleId && x.UserId == y.UserId;
        }

        public int GetHashCode(IdentityUserRole obj)
        {
            return obj == null ? 0 : obj.RoleId.GetHashCode();
        }
    }

    public enum IdentityUserRoleTypes
    {
        SiteAdmin = 100,
        CompanyAdmin = 200,
        Tech = 300,
        Caller = 400
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Fyx.Models.Organization> Organizations { get; set; }
    }
}