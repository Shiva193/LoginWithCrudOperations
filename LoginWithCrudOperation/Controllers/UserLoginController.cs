using LoginWithCrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginWithCrudOperation.Controllers
{
    public class UserLoginController : Controller
    {
        public int DefaultConnection { get; private set; }

        // GET: UserLogin
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(LoginModel lm)
        {
            string con = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            SqlCommand sqlcommand = new SqlCommand("dbo.UserLogin");
            sqlcon.Open();
            sqlcommand.Connection = sqlcon;
            sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcommand.Parameters.AddWithValue("@UserName", lm.UserName);
            sqlcommand.Parameters.AddWithValue("@Password", lm.Password);
            SqlDataReader dr = sqlcommand.ExecuteReader();
            if (dr.Read())
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewData["message"] = "Login failled";
            }
            sqlcon.Close();
            return View();
        }
        public ActionResult Welcome()
        {
            return View();
        }
    }
}