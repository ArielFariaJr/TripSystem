using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using TripSystem.Filters;
using TripSystem.ViewModels;
using System.Web.Mvc.Html;
using TripSystem.Models;


[InitializeSimpleMembership]
public class AdminMenuController : Controller
{

    public ActionResult exibeMenuAdmin()
    {

        string[] roles = { "Administrator" };
        string[] tempusers = new string[] { };
        List<string> users = new List<string>();
        foreach (string role in roles)
        {
            string[] usersInRole = Roles.GetUsersInRole(role);
            users = tempusers.Union(usersInRole).ToList();
            tempusers = users.ToArray();
        }

        foreach (string user in tempusers)
        {
            if (user == User.Identity.Name)
            {
                return PartialView("exibeMenuAdmin");
            }
        }

        return new EmptyResult();
    }
}