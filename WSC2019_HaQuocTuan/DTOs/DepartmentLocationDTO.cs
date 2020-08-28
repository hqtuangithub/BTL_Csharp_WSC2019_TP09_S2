using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DepartmentLocationDTO
    {
        public int ID { get; set; }
        public int DepartmentID { get; set; }
        public int LocationID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DepartmentLocationDTO() { }
        public DepartmentLocationDTO(int id, int departmentid, int locationid, DateTime start, DateTime end)
        {
            this.ID = id;
            this.DepartmentID = departmentid;
            this.LocationID = locationid;
            this.StartDate = start;
            this.EndDate = end;
        }
    }
}
