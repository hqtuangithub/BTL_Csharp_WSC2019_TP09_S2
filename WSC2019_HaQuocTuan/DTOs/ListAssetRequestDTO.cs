using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ListAssetRequestDTO
    {
        public string AssetSN { get; set; }
        public string AssetName { get; set; }
        public DateTime RequestDate { get; set; }
        public string  EmployeeFullName { get; set; }
        public string Department { get; set; }
        public string  Name { get; set; }
        public ListAssetRequestDTO() { }
        public ListAssetRequestDTO(string assetsn, string assetname, 
            DateTime requestdate, string fullname, string department, string name)
        {
            this.AssetSN = assetsn;
            this.AssetName = assetname;
            this.RequestDate = requestdate;
            this.EmployeeFullName = fullname;
            this.Department = department;
            this.Name = name;
        }
    }
}
