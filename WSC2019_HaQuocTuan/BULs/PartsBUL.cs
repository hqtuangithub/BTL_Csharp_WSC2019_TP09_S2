using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALs;
using DTOs;

namespace BULs
{
    public class PartsBUL
    {
        public List<PartsDTO> PartShow()
        {
            PartsDAL parts = new PartsDAL();
            return parts.PartShow();
        }

        //show danh sách Parts của Asset
        public List<PartsOfAssetDTO> PartOfAsset(string assetname, DateTime requestDate)
        {
            PartsDAL parts = new PartsDAL();
            return parts.PartOfAsset(assetname, requestDate);
        }
        //kiểm tra xem Part được thêm đã tồn tại và còn hạn sử dụng
        public bool CheckParts(int partid, string assetname, DateTime requestDate)
        {
            PartsDAL parts = new PartsDAL();
            return parts.CheckParts(partid,assetname, requestDate);
        }

        //Lấy EmergencyMaintenanceID
        public int getEmergencyMaintenanceID(string assetName, DateTime requestDate)
        {
            PartsDAL parts = new PartsDAL();
            return parts.getEmergencyMaintenanceID(assetName, requestDate);
        }

        //insert into ChangedPart
        public void AddToList(int emid, int partid, decimal amount)
        {
            PartsDAL parts = new PartsDAL();
            parts.AddToList(emid, partid, amount);
        }

        //delete from ChangedPart
        public void DeleteFromList(int emid, string assetName)
        {
            PartsDAL parts = new PartsDAL();
            parts.DeleteFromList(emid, assetName);
        }

        //Submit button
        public void SubmitEM(DateTime start, DateTime end, string note, int emid)
        {
            PartsDAL parts = new PartsDAL();
            parts.SubmitEM(start, end,note, emid);
        }
    }
}
