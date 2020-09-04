using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using LoginWithCrudOperation.Models;

namespace LoginWithCrudOperation.Database_Access_Layer
{
    public class db
    {
        string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        SqlConnection con;
        SqlCommand cmd;

        public void AddRecord(Employee emp)
        {
            SqlCommand com = new SqlCommand("Emp_Add", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name",emp.Name);
            com.Parameters.AddWithValue("@Address",emp.Address);
            com.Parameters.AddWithValue("@City", emp.City);
            com.Parameters.AddWithValue("@Designation", emp.Designation);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateRecord(Employee emp)
        {
            SqlCommand com = new SqlCommand("Emp_Update", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Emp_Id", emp.EmpId);
            com.Parameters.AddWithValue("@Name", emp.Name);
            com.Parameters.AddWithValue("@Address", emp.Address);
            com.Parameters.AddWithValue("@City", emp.City);
            com.Parameters.AddWithValue("@Designation", emp.Designation);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteRecord(Employee emp)
        {
            SqlCommand com = new SqlCommand("Emp_Delete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Emp_Id", emp.EmpId);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}