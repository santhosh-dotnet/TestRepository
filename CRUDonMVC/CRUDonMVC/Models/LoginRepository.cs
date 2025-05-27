using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CRUDonMVC.Models
{
    public class LoginRepository
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
        public bool CheckUser(string username, string password)
        {
            bool b = false;
            con.Open();
            SqlCommand cmd = new SqlCommand("user_login", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            b=Convert.ToBoolean(cmd.ExecuteScalar());
            con.Close();
            return b;
        }
        public void RegisterUser(RegisterModel obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("register_user", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", obj.Username);
            cmd.Parameters.AddWithValue("@password", obj.Password);
            cmd.Parameters.AddWithValue("@gender", obj.Gender);
            cmd.Parameters.AddWithValue("@email", obj.Email);
            cmd.Parameters.AddWithValue("@phone", obj.Phone);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void InsertEmployee(EmpModel obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employee_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obj.Eid);
            cmd.Parameters.AddWithValue("@ename", obj.Ename);
            cmd.Parameters.AddWithValue("@city", obj.City);
            cmd.Parameters.AddWithValue("@address", obj.Address);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateEmployee(EmpModel obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employee_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obj.Eid);
            cmd.Parameters.AddWithValue("@ename", obj.Ename);
            cmd.Parameters.AddWithValue("@city", obj.City);
            cmd.Parameters.AddWithValue("@address", obj.Address);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteEmployee(int id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employee_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<EmpModel> DisplayEmployee()
        {
            con.Open();
            List<EmpModel> obj = new List<EmpModel>();
            SqlCommand cmd = new SqlCommand("employee_display", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmd.ExecuteNonQuery();
            con.Close();
            foreach(DataRow dr in dt.Rows)
            {
                obj.Add(new EmpModel {
                    Eid = Convert.ToInt32(dr["id"]),
                    Ename= Convert.ToString(dr["ename"]),
                    City= Convert.ToString(dr["city"]),
                    Address=Convert.ToString(dr["address"])
                });
            }
            return obj;
        }
    }
}