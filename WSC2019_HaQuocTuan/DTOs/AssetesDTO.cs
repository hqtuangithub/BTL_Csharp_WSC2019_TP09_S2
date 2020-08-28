using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AssetsDTO
    {
        public int ID { get; set; }
        public string AssetSN { get; set; }
        public string AssetName { get; set; }
        public int DepartmentLocationID { get; set; }
        public int EmployeeID { get; set; }
        public int AssetGroupID { get; set; }
        public string Description { get; set; }
        public DateTime WarrantyDate { get; set; }

        public AssetsDTO() { }
        public AssetsDTO(int id, string assetsn, string assetname, int departmentlocationid, int employeeid, int assetgroupid, string description, DateTime warrantydate)
        {
            this.ID = id;
            this.AssetSN = assetsn;
            this.AssetName = assetname;
            this.DepartmentLocationID = departmentlocationid;
            this.EmployeeID = employeeid;
            this.AssetGroupID = assetgroupid;
            this.Description = description;
            this.WarrantyDate = warrantydate;
        }
    }
}
