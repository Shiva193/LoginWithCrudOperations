using LoginWithCrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;

namespace LoginWithCrudOperation.Database_Access_Layer
{
    public class db1
    {
        string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        SqlConnection con;
        SqlCommand cmd;
        public IEnumerable<Employee>EmpList
        {
            get
            {
                List<Employee> employees = new List<Employee>();
                con = new SqlConnection(strcon);
                con.Open();
                cmd = new SqlCommand("Emp_All", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Employee employee = new Employee();
                    employee.EmpId = Convert.ToInt32(dr["Emp_Id"]);
                    employee.Name =dr["Name"].ToString();
                    employee.Address = dr["Address"].ToString();
                    employee.City = dr["City"].ToString();
                    employee.Designation = dr["Designation"].ToString();
                    employee.Age = dr["Age"].ToString();
                    employee.MobileNo = dr["Mobile No"].ToString();
                    employee.Gender = dr["Gender"].ToString();
                    employee.EmailId = dr["EmailId"].ToString();
                    employee.ImageName = dr["ImageName"].ToString();
                    employees.Add(employee);
                }
                dr.Close();
                con.Close();
                return employees;
            }
        }
        public IEnumerable<Product> GetPruducts
        {
            get
            {
                List<Product> products = new List<Product>();
                con = new SqlConnection(strcon);
                con.Open();
                cmd = new SqlCommand("Product_All", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                   Product product = new Product();
                    product.ProductId = dr["ProductId"].ToString(); 
                    product.UserId = dr["UserId"].ToString();
                    product.Name = dr["Name"].ToString();
                    product.ActualPrice = Convert.ToInt32(dr["ActualPrice"]);
                    product.FinalPrice = Convert.ToInt32(dr["FinalPrice"]);
                    product.OfferPrice = Convert.ToInt32(dr["OfferPrice"]);
                    product.SaleCommission = Convert.ToInt32(dr["SaleCommission"]);
                    product.ImagePath = dr["ImagePath"].ToString();
                    product.Description = dr["Description"].ToString();
                    product.Status = dr["Status"].ToString();
                    product.Category = dr["Category"].ToString();
                    product.ImagePath2 = dr["ImagePath2"].ToString();
                    product.ImagePath3 = dr["ImagePath3"].ToString();
                    product.ImagePath4 = dr["ImagePath4"].ToString();
                    products.Add(product);
                }
                dr.Close();
                con.Close();
                return products;
            }
        }
        public void AddProduct(Product p)
        {
            con = new SqlConnection(strcon);
            con.Open();
            cmd = new SqlCommand("Product_Add", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramProductId = new SqlParameter();
            paramProductId.ParameterName = "@ProductId";
            paramProductId.Value = "";
            cmd.Parameters.Add(paramProductId);

            SqlParameter paramUserId = new SqlParameter();
            paramUserId.ParameterName = "@UserId";
            paramUserId.Value = p.UserId;
            cmd.Parameters.Add(paramUserId);

            SqlParameter paramName = new SqlParameter();
            paramName.ParameterName = "@Name";
            paramName.Value = p.Name;
            cmd.Parameters.Add(paramName);

            SqlParameter paramActualPrice = new SqlParameter();
            paramActualPrice.ParameterName = "@ActualPrice";
            paramActualPrice.Value = p.ActualPrice;
            cmd.Parameters.Add(paramActualPrice);

            SqlParameter paramFinalPrice = new SqlParameter();
            paramFinalPrice.ParameterName = "@FinalPrice";
            paramFinalPrice.Value = p.FinalPrice;
            cmd.Parameters.Add(paramFinalPrice);

            SqlParameter paramOfferPrice = new SqlParameter();
            paramOfferPrice.ParameterName = "@OfferPrice";
            paramOfferPrice.Value = p.OfferPrice;
            cmd.Parameters.Add(paramOfferPrice);

            SqlParameter paramSaleCommission = new SqlParameter();
            paramSaleCommission.ParameterName = "@SaleCommission";
            paramSaleCommission.Value = p.SaleCommission;
            cmd.Parameters.Add(paramSaleCommission);

            SqlParameter paramImagePath = new SqlParameter();
            paramImagePath.ParameterName = "@ImagePath";
            paramImagePath.Value =p.ImagePath;
            cmd.Parameters.Add(paramImagePath);

            SqlParameter paramDescription = new SqlParameter();
            paramDescription.ParameterName = "@Description";
            paramDescription.Value = p.Description;
            cmd.Parameters.Add(paramDescription);

            SqlParameter paramStatus = new SqlParameter();
            paramStatus.ParameterName = "@Status";
            paramStatus.Value = p.Status;
            cmd.Parameters.Add(paramStatus);

            SqlParameter paramCategory = new SqlParameter();
            paramCategory.ParameterName = "@Category";
            paramCategory.Value = p.Category;
            cmd.Parameters.Add(paramCategory);

            SqlParameter paramImagePath2 = new SqlParameter();
            paramImagePath2.ParameterName = "@ImagePath2";
            paramImagePath2.Value = p.ImagePath2;
            cmd.Parameters.Add(paramImagePath2);

            SqlParameter paramImagePath3 = new SqlParameter();
            paramImagePath3.ParameterName = "@ImagePath3";
            paramImagePath3.Value =p.ImagePath3;
            cmd.Parameters.Add(paramImagePath3);

            SqlParameter paramImagePath4 = new SqlParameter();
            paramImagePath4.ParameterName = "@ImagePath4";
            paramImagePath4.Value =p.ImagePath4;
            cmd.Parameters.Add(paramImagePath4);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateProduct(Product p)
        {
            con = new SqlConnection(strcon);
            con.Open();

            cmd = new SqlCommand("Product_Add", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramProductId = new SqlParameter("@ProductId", p.ProductId);
            cmd.Parameters.Add(paramProductId);
            SqlParameter paramUserId = new SqlParameter("@UserId", p.UserId);
            cmd.Parameters.Add(paramUserId);
            SqlParameter paramName = new SqlParameter("@Name", p.Name);
            cmd.Parameters.Add(paramName);
            SqlParameter paramActualPrice = new SqlParameter("@ActualPrice", p.ActualPrice);
            cmd.Parameters.Add(paramActualPrice);
            SqlParameter paramFinalPrice = new SqlParameter("@FinalPrice", p.FinalPrice);
            cmd.Parameters.Add(paramFinalPrice);
            SqlParameter paramOfferPrice = new SqlParameter("@OfferPrice", p.OfferPrice);
            cmd.Parameters.Add(paramOfferPrice);
            SqlParameter paramSaleCommission = new SqlParameter("@SaleCommission", p.SaleCommission);
            cmd.Parameters.Add(paramSaleCommission);
            SqlParameter paramImagePath = new SqlParameter("@ImagePath",p.ImagePath);
            cmd.Parameters.Add(paramImagePath);
            SqlParameter paramDescription = new SqlParameter("@Description", p.Description);
            cmd.Parameters.Add(paramDescription);
            SqlParameter paramStatus = new SqlParameter("@Status", p.Status);
            cmd.Parameters.Add(paramStatus);
            SqlParameter paramCategory = new SqlParameter("@Category", p.Category);
            cmd.Parameters.Add(paramCategory);
            SqlParameter paramImagePath2 = new SqlParameter("@ImagePath2",p.ImagePath2);
            cmd.Parameters.Add(paramImagePath2);
            SqlParameter paramImagePath3 = new SqlParameter("@ImagePath3",p.ImagePath3);
            cmd.Parameters.Add(paramImagePath3);
            SqlParameter paramImagePath4 = new SqlParameter("@ImagePath4",p.ImagePath4);
            cmd.Parameters.Add(paramImagePath4);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteProduct(string id)
        {
            con = new SqlConnection(strcon);
            con.Open();

            cmd = new SqlCommand("Product_Delete", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductId", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void AddRecord(Employee emp, string filename)
        {
            con = new SqlConnection(strcon);
            con.Open();

            cmd = new SqlCommand("Emp_Add", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramName = new SqlParameter();
            paramName.ParameterName = "@Name";
            paramName.Value = emp.Name;
            cmd.Parameters.Add(paramName);

            SqlParameter paramAddress = new SqlParameter();
            paramAddress.ParameterName = "@Address";
            paramAddress.Value = emp.Address;
            cmd.Parameters.Add(paramAddress);

            SqlParameter paramCity = new SqlParameter();
            paramCity.ParameterName = "@City";
            paramCity.Value = emp.City;
            cmd.Parameters.Add(paramCity);

            SqlParameter paramDesignation = new SqlParameter();
            paramDesignation.ParameterName = "@Designation";
            paramDesignation.Value = emp.Designation;
            cmd.Parameters.Add(paramDesignation);

            SqlParameter paramAge = new SqlParameter();
            paramAge.ParameterName = "@Age";
            paramAge.Value = emp.Age;
            cmd.Parameters.Add(paramAge);

            SqlParameter paramMobileNo = new SqlParameter();
            paramMobileNo.ParameterName = "@MobileNo";
            paramMobileNo.Value = emp.MobileNo;
            cmd.Parameters.Add(paramMobileNo);

            SqlParameter paramGender = new SqlParameter();
            paramGender.ParameterName = "@Gender";
            paramGender.Value = emp.Gender;
            cmd.Parameters.Add(paramGender);

            SqlParameter paramEmailId = new SqlParameter();
            paramEmailId.ParameterName = "@EmailId";
            paramEmailId.Value = emp.EmailId;
            cmd.Parameters.Add(paramEmailId);

            SqlParameter paramImageName = new SqlParameter();
            paramImageName.ParameterName = "@ImageName";
            paramImageName.Value = filename;
            cmd.Parameters.Add(paramImageName);
           
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateRecord(Employee emp, string filename)
        {
            con = new SqlConnection(strcon);
            con.Open();

            cmd = new SqlCommand("Emp_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramId = new SqlParameter("@Emp_Id", emp.EmpId);
            cmd.Parameters.Add(paramId);

            SqlParameter paramName = new SqlParameter("@Name", emp.Name);
            cmd.Parameters.Add(paramName);

            SqlParameter paramAddress = new SqlParameter("@Address", emp.Address);
            cmd.Parameters.Add(paramAddress);

            SqlParameter paramCity = new SqlParameter("@City", emp.City);
            cmd.Parameters.Add(paramCity);

            SqlParameter paramDesignation = new SqlParameter("@Designation", emp.Designation);
            cmd.Parameters.Add(paramDesignation);

            SqlParameter paramAge = new SqlParameter("@Age", emp.Age);
            cmd.Parameters.Add(paramAge);

            SqlParameter paramMobileNo = new SqlParameter("@MobileNo", emp.MobileNo);
            cmd.Parameters.Add(paramMobileNo);

            SqlParameter paramGender = new SqlParameter("@Gender", emp.Gender);
            cmd.Parameters.Add(paramGender);

            SqlParameter paramEmailId = new SqlParameter("@EmailId", emp.EmailId);
            cmd.Parameters.Add(paramEmailId);

            SqlParameter paramImageName = new SqlParameter("@ImageName", filename);
            cmd.Parameters.Add(paramImageName);

            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void DeleteRecord(int id)
        {
            con = new SqlConnection(strcon);
            con.Open();

            cmd = new SqlCommand("Emp_Delete", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Emp_Id",id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}