using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace DALs
{
    public class EmployesRequestDAL
    {
        public static string StringConnection = @"Data Source=HAQUOCTUAN\SQLEXPRESS;Initial Catalog=Session2;Integrated Security=True";
        SqlConnection conn = new SqlConnection(StringConnection);

        //Hiển thị Department theo Asset được chọn
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

        //Hiển thị cbb Priorities
        public List<PrioritiesDTO> PrioritiyShow()
        {
            conn.Open();
            List<PrioritiesDTO> listPriority = new List<PrioritiesDTO>();

            string query = "select * from Priorities";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            //đọc từng dòng, chuyển từng dòng thành đối tượng DTO và thêm vào list
            while (dr.Read())
            {
                PrioritiesDTO priorities = new PrioritiesDTO(Convert.ToInt32(dr[0]),
                                                dr["Name"].ToString());

                listPriority.Add(priorities);
            }
            dr.Close();
            conn.Close();
            return listPriority;
        }

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
