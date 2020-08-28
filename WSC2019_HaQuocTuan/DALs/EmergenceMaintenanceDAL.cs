using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace DALs
{
    public class EmergenceMaintenanceDAL
    {
        public static string StringConnection = @"Data Source=HAQUOCTUAN\SQLEXPRESS;Initial Catalog=Session2;Integrated Security=True";
        SqlConnection conn = new SqlConnection(StringConnection);

        //get assetID
        public int getEmergencyMaintenanceID(string assetSN, string assetName)
        {
            conn.Open();
            string query = "select ID from Assets where AssetSN = @assetsn and AssetName = @assetname";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("assetsn", assetSN);
            cmd.Parameters.AddWithValue("assetname", assetName);
            SqlDataReader dr = cmd.ExecuteReader();
            int id = 0;
            while (dr.Read())
            {
                id = Convert.ToInt32(dr["ID"]);
            }

            dr.Close();
            conn.Close();
            return id;
        }

        //insert
        public void InsertEM(int assetid, int priorityid, string description, string other)
        {
            conn.Open();
            string query = "insert into EmergencyMaintenances values " +
                "( @assetid, @priorityid, @description, @other,CAST(@requestDate AS Date) , " +
                "NULL, NULL, NULL)";
            SqlCommand cmd = new SqlCommand(query, conn); 
            cmd.Parameters.AddWithValue("assetid", assetid); 
            cmd.Parameters.AddWithValue("priorityid", priorityid);
            cmd.Parameters.AddWithValue("description", description);
            cmd.Parameters.AddWithValue("other", other);

            DateTime requestDate = DateTime.Today;
            string rd = requestDate.ToString("yyyy-MM-dd");
            //cmd.Parameters.Add("@requestDate", SqlDbType.DateTime).Value = requestDate.Date;
            cmd.Parameters.AddWithValue("requestDate", rd);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
