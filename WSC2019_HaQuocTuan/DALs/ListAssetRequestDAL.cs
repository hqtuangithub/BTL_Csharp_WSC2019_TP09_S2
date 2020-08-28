using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace DALs
{
    public class ListAssetRequestDAL
    {
        public static string StringConnection = @"Data Source=HAQUOCTUAN\SQLEXPRESS;Initial Catalog=Session2;Integrated Security=True";
        SqlConnection conn = new SqlConnection(StringConnection);

        //nhân viên đănh nhập
        public List<ListAssetRequestDTO> AssetRequestShow()
        {
            conn.Open();
            List<ListAssetRequestDTO> listAssetRequest = new List<ListAssetRequestDTO>();

            string query = "select Priorities.ID, AssetSN, AssetName, EMReportDate, CONCAT( Employees.FirstName,' ', Employees.LastName) as N'FullName', Departments.Name, Priorities.Name as N'PName' from Employees inner join Assets on Employees.ID = Assets.EmployeeID inner join EmergencyMaintenances on EmergencyMaintenances.AssetID = Assets.ID inner join DepartmentLocations on DepartmentLocations.ID = Assets.DepartmentLocationID inner join Departments on Departments.ID = DepartmentLocations.DepartmentID inner join Priorities on Priorities.ID = EmergencyMaintenances.PriorityID order by Priorities.ID desc, EMReportDate asc";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            //đọc từng dòng, chuyển từng dòng thành đối tượng DTO và thêm vào list
            while (dr.Read())
            {
                ListAssetRequestDTO assetDTO = new ListAssetRequestDTO(dr[0].ToString(),
                                                dr["AssetName"].ToString(),
                                              Convert.ToDateTime(  dr["EMReportDate"]),
                                                dr["FullName"].ToString(),
                                                dr["Name"].ToString(),
                                                dr["PName"].ToString());
                                            

                listAssetRequest.Add(assetDTO);
            }
            dr.Close();
            conn.Close();
            return listAssetRequest;
        }
    }
}
