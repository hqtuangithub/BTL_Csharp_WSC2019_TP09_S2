using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALs;
using DTOs;

namespace BULs
{
    public class MaintenanceDetailBUL
    {
        //Hiển thị Department theo Asset được chọn
        public string DepartmentRequest(string assetname)
        {
            MaintenanceDetailDAL assets = new MaintenanceDetailDAL();
            return assets.DepartmentRequest(assetname);
        }

        public List<PartsDTO> PartShow()
        {
            MaintenanceDetailDAL parts = new MaintenanceDetailDAL();
            return parts.PartShow();
        }

        //show danh sách Parts của Asset
        public List<PartsOfAssetDTO> PartOfAsset(string assetname, DateTime requestDate)
        {
            MaintenanceDetailDAL parts = new MaintenanceDetailDAL();
            return parts.PartOfAsset(assetname, requestDate);
        }

        //kiểm tra xem Part được thêm đã tồn tại và còn hạn sử dụng
        public bool CheckParts(int partid, string assetname, DateTime requestDate)
        {
            MaintenanceDetailDAL parts = new MaintenanceDetailDAL();
            return parts.CheckParts(partid, assetname, requestDate);
        }

        //Lấy EmergencyMaintenanceID
        public int getEmergencyMaintenanceID(string assetName, DateTime requestDate)
        {
            MaintenanceDetailDAL parts = new MaintenanceDetailDAL();
            return parts.getEmergencyMaintenanceID(assetName, requestDate);
        }

        //insert into ChangedPart
        public void AddToList(int emid, int partid, decimal amount)
        {
            MaintenanceDetailDAL parts = new MaintenanceDetailDAL();
            parts.AddToList(emid, partid, amount);
        }

        //delete from ChangedPart
        public void DeleteFromList(int emid, string assetName)
        {
            MaintenanceDetailDAL parts = new MaintenanceDetailDAL();
            parts.DeleteFromList(emid, assetName);
        }

        //Submit button
        public void SubmitEM(DateTime start, DateTime end, string note, int emid)
        {
            MaintenanceDetailDAL parts = new MaintenanceDetailDAL();
            parts.SubmitEM(start, end, note, emid);
        }
    }
}
