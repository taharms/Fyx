using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.SqlClient;
using Fyx.Models;

namespace Fyx.Web.Models
{
    public static class QueryableExtensions
    {
        public static Microsoft.AspNet.Identity.EntityFramework.IdentityRole GetRoleByEnumType(this IQueryable<Microsoft.AspNet.Identity.EntityFramework.IdentityRole> query, IdentityUserRoleTypes roleType)
        {
            return query.Where(r => r.Name == roleType.ToString()).FirstOrDefault();
        }
    }
    
}