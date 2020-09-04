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
    public class UserRegistrationController : Controller
    {
        // GET: UserRegistration
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(UserReg ur)
        {
            string con = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            SqlCommand sqlcommand = new SqlCommand("dbo.RegUserDetails");
            sqlcon.Open();
            sqlcommand.Connection = sqlcon;
            sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcommand.Parameters.AddWithValue("@UserName", ur.UserName);
            sqlcommand.Parameters.AddWithValue("@EmailId", ur.EmailId);
            sqlcommand.Parameters.AddWithValue("@MobileNo", ur.MobileNo);
            sqlcommand.Parameters.AddWithValue("@Password", ur.Password);
            SqlDataReader dr = sqlcommand.ExecuteReader();
            dr.Read();
            ViewData["Message"] = "The New Employee" + ur.UserName + "is saved successfully...";
            return View(ur);
        }
    }
}