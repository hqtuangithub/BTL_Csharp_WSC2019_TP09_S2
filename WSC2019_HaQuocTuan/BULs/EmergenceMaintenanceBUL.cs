using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALs;
using DTOs;

namespace BULs
{
    public class EmergenceMaintenanceBUL
    {
        //get assetID
        public int getEmergencyMaintenanceID(string assetSN, string assetName)
        {
            EmergenceMaintenanceDAL em = new EmergenceMaintenanceDAL();
            return em.getEmergencyMaintenanceID(assetSN, assetName);
        }
        //
        //insert EM
        //insert
        public void InsertEM(int assetid, int priorityid, string description,
            string other)
        {
            EmergenceMaintenanceDAL em = new EmergenceMaintenanceDAL();
            em.InsertEM(assetid, priorityid, description, other);
        }
    }
}
