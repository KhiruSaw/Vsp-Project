using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VSPApplication.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace VSPApplication.Controllers
{
    public class HomeController : Controller
    {
        public SqlConnection cn;
        public SqlCommand cmd;
        public String connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
      

    }
}