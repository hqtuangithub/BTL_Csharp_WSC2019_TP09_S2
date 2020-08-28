using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using DALs;

namespace BULs
{
    public class MaintenanceBUL
    {
        public List<ListAssetRequestDTO> AssetRequestShow()
        {
            MaintenanceDAL listAssetRequest = new MaintenanceDAL();
            return listAssetRequest.AssetRequestShow();
        }
    }
}
