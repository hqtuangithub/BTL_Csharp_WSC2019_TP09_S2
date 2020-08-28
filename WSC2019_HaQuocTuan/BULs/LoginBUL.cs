using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using DALs;

namespace BULs
{
    public class LoginBUL
    {
        public bool EmployeeLogin(string username, string password)
        {
            LoginDAL login = new LoginDAL();
            if (login.EmployeeLogin(username, password) == true)
                return true;
            else
                return false;
        }

        public bool IsAdminLogin(string username, string password)
        {
            LoginDAL login = new LoginDAL();
            if (login.IsAdminLogin(username, password) == true)
                return true;
            else
                return false;
        }
    }
}
