using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALs;
using DTOs;

namespace BULs
{
    public class EmployeeBUL
    {
        //hiển thị danh sách Available Asset
        public List<ListAvailableAssetDTO> ShowAvailableAsset(string username)
        {
            EmployeeDAL list = new EmployeeDAL();
            return list.AvailableAsset(username);
        }
    }
}
