using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;

namespace TripSystem.Controllers
{
    public class UsersProvider
    {
        public void PutUserInRole(string user)
        {
            var rolesProvider = (SimpleRoleProvider)Roles.Provider;
            
            if (user == "afaria" | user == "mbraz" | user == "gbatista")
            {
                if (!rolesProvider.RoleExists("Administrator"))
                {
                    rolesProvider.CreateRole("Administrator");
                }

                if (!rolesProvider.IsUserInRole(user, "Administrator"))
                {
                    rolesProvider.AddUsersToRoles(new[] { user }, new[] { "Administrator" });
                }
            }

        }
    }
}