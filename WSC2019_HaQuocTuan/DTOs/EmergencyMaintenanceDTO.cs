using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class EmergencyMaintenanceDTO
    {
        public int ID { get; set; }
        public int AssetID { get; set; }
        public int PriorityID { get; set; }
        public string DescriptionEmergency { get; set; }
        public string OtherConsiderations { get; set; }
        public DateTime EMReportDate { get; set; }
        public DateTime EMStartDate { get; set; }
        public DateTime EMEndDate { get; set; }
        public string EMTechnicianNote { get; set; }

        public EmergencyMaintenanceDTO() { }
        public EmergencyMaintenanceDTO(int id, int assetid, int priority, string description, string othercondider, DateTime reportdate,
            DateTime startdate, DateTime enddate, string techniciannote)
        {
            this.ID = id;
            this.AssetID = assetid;
            this.PriorityID = priority;
            this.DescriptionEmergency = description;
            this.OtherConsiderations = othercondider;
            this.EMReportDate = reportdate;
            this.EMStartDate = startdate;
            this.EMEndDate = enddate;
            this.EMTechnicianNote = techniciannote;
        }
    }
}
