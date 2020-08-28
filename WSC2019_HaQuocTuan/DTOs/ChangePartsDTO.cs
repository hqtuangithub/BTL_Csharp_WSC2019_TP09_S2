using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ChangePartsDTO
    {
        public int ID { get; set; }
        public int EmergencyMaintenanceID { get; set; }
        public int PartID { get; set; }
        public decimal Amount { get; set; }

        public ChangePartsDTO() { }
        public ChangePartsDTO(int id, int emergencymaintenanceID, int partid, decimal amount)
        {
            this.ID = id;
            this.EmergencyMaintenanceID = emergencymaintenanceID;
            this.PartID = partid;
            this.Amount = amount;
        }
    }
}
