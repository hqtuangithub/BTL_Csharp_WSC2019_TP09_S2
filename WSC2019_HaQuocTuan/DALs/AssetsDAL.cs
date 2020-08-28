using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALs
{
    public class AssetsDAL
    {
        public static string StringConnection = @"Data Source=HAQUOCTUAN\SQLEXPRESS;Initial Catalog=Session2;Integrated Security=True";
        SqlConnection conn = new SqlConnection(StringConnection);
        public string DepartmentRequest(string assetname)
        {
            conn.Open();
           
            string query = "select Departments.Name from Assets inner join DepartmentLocations on Assets.DepartmentLocationID = DepartmentLocations.ID " +
                "inner join Departments on Departments.ID = DepartmentLocations.DepartmentID " +
                "where Assets.AssetName = @assetname";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("assetname", assetname);
            SqlDataReader dr = cmd.ExecuteReader();
            string result = "";
            while (dr.Read())
            {
                result = dr.GetString(0);
            }
            conn.Close();
            return result;
        }
    }
}
