using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VSPApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Session_Start()
        {
            if (Session["firstName"] == null)
            {
                //Redirect to Welcome Page if Session is not null  
                Response.Redirect("~/Account/Login");
                //HttpContext.Current.Response.Redirect("~/Account/Login", false);

            }
            //else
            //{
            //    //Redirect to Login Page if Session is null & Expires                  
            //    new RedirectToRouteResult(new RouteValueDictionary { { "action", "Login" }, { "controller", "Account" } });
            //}
        }

    }
}
