using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace DALs
{
    public class ListAvailableAssetDAL
    {
        public static string StringConnection = @"Data Source=HAQUOCTUAN\SQLEXPRESS;Initial Catalog=Session2;Integrated Security=True";
        SqlConnection conn = new SqlConnection(StringConnection);

        //nhân viên đănh nhập
        public List<ListAvailableAssetDTO> AvailableAsset(string username)
        {
            conn.Open();
            List<ListAvailableAssetDTO> listAvailableAsset = new List<ListAvailableAssetDTO>();

            string query = "select AssetSN , AssetName , EMEndDate, Amount " +
                "from Assets inner join EmergencyMaintenances on Assets.ID = EmergencyMaintenances.AssetID " +
                "inner join ChangedParts on ChangedParts.EmergencyMaintenanceID = EmergencyMaintenances.ID " +
                "inner join Employees on Employees.ID = Assets.EmployeeID " +
                "where Employees.Username = @username";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("username", username);
            SqlDataReader dr = cmd.ExecuteReader();
            //đọc từng dòng, chuyển từng dòng thành đối tượng DTO và thêm vào list
            while (dr.Read())
            {
                ListAvailableAssetDTO assetDTO = new ListAvailableAssetDTO(dr[0].ToString(),
                                                dr["AssetName"].ToString(),
                                                dr["EmEndDate"].ToString(),
                                                Convert.ToInt32(dr["Amount"]));

                listAvailableAsset.Add(assetDTO);
            }
            dr.Close();
            conn.Close();
            return listAvailableAsset;
        }



    }
}
