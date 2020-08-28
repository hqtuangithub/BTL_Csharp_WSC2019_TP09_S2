using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALs;
using DTOs;

namespace BULs
{
    public class ListAvailableAssetBUL
    {
        public List<ListAvailableAssetDTO> ShowAvailableAsset(string username)
        {
            ListAvailableAssetDAL list = new ListAvailableAssetDAL();
            return list.AvailableAsset(username);
        }
    }
}
