using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALs;

namespace BULs
{
    public class AssetsBUL
    {
        public string DepartmentRequest(string assetname)
        {
            AssetsDAL assets = new AssetsDAL();
            return assets.DepartmentRequest(assetname);
        }
    }
}
