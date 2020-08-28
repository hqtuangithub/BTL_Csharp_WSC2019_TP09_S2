using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;


namespace DALs
{
    public class PrioritiesDAL
    {
        public static string StringConnection = @"Data Source=HAQUOCTUAN\SQLEXPRESS;Initial Catalog=Session2;Integrated Security=True";
        SqlConnection conn = new SqlConnection(StringConnection);

        //nhân viên đănh nhập
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
    }
}
