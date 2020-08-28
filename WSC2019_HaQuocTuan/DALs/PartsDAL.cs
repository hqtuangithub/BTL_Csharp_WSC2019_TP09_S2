using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace DALs
{
    public class PartsDAL
    {
        public static string StringConnection = @"Data Source=HAQUOCTUAN\SQLEXPRESS;Initial Catalog=Session2;Integrated Security=True";
        SqlConnection conn = new SqlConnection(StringConnection);

        //Danh sách Parts trong cbb
        public List<PartsDTO> PartShow()
        {
            conn.Open();
            List<PartsDTO> listParts = new List<PartsDTO>();

            string query = "select * from Parts";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            //đọc từng dòng, chuyển từng dòng thành đối tượng DTO và thêm vào list
            while (dr.Read())
            {
                PartsDTO part = new PartsDTO(Convert.ToInt32(dr[0]),
                                                dr["Name"].ToString(),
                                                dr["EffectiveLife"].ToString());

                listParts.Add(part);
            }
            dr.Close();
            conn.Close();
            return listParts;
        }

        //show danh sách Parts của Asset
        public List<PartsOfAssetDTO> PartOfAsset(string assetname, DateTime requestDate)
        {
            conn.Open();
            List<PartsOfAssetDTO> listParts = new List<PartsOfAssetDTO>();

            string query = "select Parts.Name, ChangedParts.Amount " +
                "from Parts inner join ChangedParts on Parts.ID = ChangedParts.PartID " +
                "inner join EmergencyMaintenances on EmergencyMaintenances.ID = ChangedParts.EmergencyMaintenanceID " +
                "inner join Assets on EmergencyMaintenances.AssetID = Assets.ID " +
                "where AssetName = @assetName and EmergencyMaintenances.EMReportDate = @requestDate";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("assetName", assetname);
            cmd.Parameters.AddWithValue("requestDate", requestDate);
            SqlDataReader dr = cmd.ExecuteReader();
            //đọc từng dòng, chuyển từng dòng thành đối tượng DTO và thêm vào list
            while (dr.Read())
            {
                PartsOfAssetDTO part = new PartsOfAssetDTO(dr[0].ToString(),
                                                Convert.ToDecimal(dr["Amount"]));

                listParts.Add(part);
            }
            dr.Close();
            conn.Close();
            return listParts;
        }

        //kiểm tra xem Part được thêm đã tồn tại và còn hạn sử dụng
        public bool CheckParts(int partid,string assetname, DateTime requestDate)
        {
            conn.Open();
            List<PartsDTO> listParts = new List<PartsDTO>();
            //tìm Part đang được sử dụng và effective life còn
            string query = "select Parts.ID, Parts.Name, Parts.EffectiveLife " +
                "from Parts inner join ChangedParts on Parts.ID = ChangedParts.PartID " +
                "inner join EmergencyMaintenances on EmergencyMaintenances.ID = ChangedParts.EmergencyMaintenanceID " +
                "inner join Assets on EmergencyMaintenances.AssetID = Assets.ID " +
                "where Parts.ID = @partid  and AssetName = @assetName " + //or Parts.EffectiveLife > 0
                "and EmergencyMaintenances.EMReportDate = @requestDate";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("partid", partid);
            cmd.Parameters.AddWithValue("requestDate", requestDate);
            cmd.Parameters.AddWithValue("assetName", assetname);
            SqlDataReader dr = cmd.ExecuteReader();
            //đọc từng dòng, chuyển từng dòng thành đối tượng DTO và thêm vào list
            while (dr.Read())
            {
                PartsDTO part = new PartsDTO(Convert.ToInt32(dr[0]),
                                                dr["Name"].ToString(),
                                                dr["EffectiveLife"].ToString());

                listParts.Add(part);
            }
            dr.Close();
            conn.Close();
            //nếu tồn tại
            if (listParts.Count > 0)
                return false;
            else
                return true;
        }

        //Thêm vào danh sách Part của Asset
        //Thêm Parts.Name, ChangedParts.Amount, AssetName,EmergencyMaintenances.EMReportDate,


        //Lấy EmergencyMaintenanceID
        public int getEmergencyMaintenanceID(string assetName, DateTime requestDate)
        {
            conn.Open();
            string query = "select EmergencyMaintenances.ID " +
                "from EmergencyMaintenances inner join Assets " +
                "on EmergencyMaintenances.AssetID = Assets.ID " +
                "where AssetName = @assetname " +
                "and EmergencyMaintenances.EMReportDate = @requestDate";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("assetname", assetName);
            cmd.Parameters.AddWithValue("requestDate", requestDate);
            SqlDataReader dr = cmd.ExecuteReader();
            int str = 0;
            while (dr.Read())
            {
                str = Convert.ToInt32(dr["ID"]);
            }
            
            dr.Close();
            conn.Close();
            return str;
        }


        //insert into ChangedPart
        public void AddToList(int emid, int partid, decimal amount)
        {
            conn.Open();
            string query = "insert into ChangedParts values(@emid,@partid,@amount)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("emid", emid);
            cmd.Parameters.AddWithValue("partid", partid);
            cmd.Parameters.AddWithValue("amount", amount);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //delete from ChangedPart
        public void DeleteFromList(int emid, string assetName)
        {
            conn.Open();
            string query = "delete from ChangedParts " +
                "where ChangedParts.ID = " +
                "(select ChangedParts.ID from Parts inner join ChangedParts on Parts.ID = ChangedParts.PartID " +
                "inner join EmergencyMaintenances on EmergencyMaintenances.ID = ChangedParts.EmergencyMaintenanceID " +
                "inner join Assets on EmergencyMaintenances.AssetID = Assets.ID " +
                "where Parts.Name = @assetName and EmergencyMaintenanceID = @emid)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("emid", emid);
            cmd.Parameters.AddWithValue("assetName", assetName);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Submit button
        public void SubmitEM(DateTime start, DateTime end, string note, int emid)
        {
            conn.Open();
            string query = "update EmergencyMaintenances " +
                "set EMStartDate = @startdate, EMEndDate = @enddate, EMTechnicianNote = @note " +
                "where ID = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("startdate", start);
            cmd.Parameters.AddWithValue("enddate", end);
            cmd.Parameters.AddWithValue("note", note);
            cmd.Parameters.AddWithValue("id", emid);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
