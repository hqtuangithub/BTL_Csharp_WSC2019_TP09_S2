using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using DALs;

namespace BULs
{
    public class EmployesRequestBUL
    {

        //Hiển thị Department theo Asset được chọn
        public string DepartmentRequest(string assetname)
        {
            EmployesRequestDAL assets = new EmployesRequestDAL();
            return assets.DepartmentRequest(assetname);
        }

        //Hiển thị cbb Priorities
        public List<PrioritiesDTO> PrioritiyShow()
        {
            EmployesRequestDAL priorities = new EmployesRequestDAL();
            return priorities.PrioritiyShow();
        }

        //get assetID
        public int getEmergencyMaintenanceID(string assetSN, string assetName)
        {
            EmployesRequestDAL em = new EmployesRequestDAL();
            return em.getEmergencyMaintenanceID(assetSN, assetName);
        }
        //
        //insert EM
        //insert
        public void InsertEM(int assetid, int priorityid, string description,
            string other)
        {
            EmployesRequestDAL em = new EmployesRequestDAL();
            em.InsertEM(assetid, priorityid, description, other);
        }
    }
}
