using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using DALs;

namespace BULs
{
    public class ListAssetRequestBUL
    {
        public List<ListAssetRequestDTO> AssetRequestShow()
        {
            ListAssetRequestDAL listAssetRequest = new ListAssetRequestDAL();
            return listAssetRequest.AssetRequestShow();
        }
    }
}
