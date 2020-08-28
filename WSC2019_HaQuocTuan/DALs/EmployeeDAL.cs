using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DALs
{
    public class EmployeeDAL
    {
        public static string StringConnection = @"Data Source=HAQUOCTUAN\SQLEXPRESS;Initial Catalog=Session2;Integrated Security=True";
        SqlConnection conn = new SqlConnection(StringConnection);

        //nhân viên đănh nhập
        public bool EmployeeLogin(string username, string password)
        {
            conn.Open();
            string query = "select * from Employees where Username = @name and Password = @pass";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("name", username);
            cmd.Parameters.AddWithValue("pass", password);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count == 0)
                return false;
            else return true;
            conn.Close();
        }

        //kiểm tra nhân viên có phải là admin không
        public bool IsAdminLogin(string username, string password)
        {
            conn.Open();
            string query = "select * from Employees where Username = @name and Password = @pass and isAdmin = 1";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("name", username);
            cmd.Parameters.AddWithValue("pass", password);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count == 0)
                return false;
            else return true;
            conn.Close();
        }
    }
}
