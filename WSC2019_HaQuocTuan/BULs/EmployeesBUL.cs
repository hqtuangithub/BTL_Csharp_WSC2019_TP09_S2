using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using DALs;
namespace BULs
{
    public class EmployeesBUL
    {
        public bool EmployeeLogin(string username, string password)
        {
            EmployeeDAL employeeDAL = new EmployeeDAL();
            if (employeeDAL.EmployeeLogin(username, password) == true)
                return true;
            else
                return false;
        }

        public bool IsAdminLogin(string username, string password)
        {
            EmployeeDAL employeeDAL = new EmployeeDAL();
            if (employeeDAL.IsAdminLogin(username, password) == true)
                return true;
            else
                return false;
        }
    }
}
