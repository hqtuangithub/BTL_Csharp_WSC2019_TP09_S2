using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class EmployeesDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public string Phone { get; set; }
        public int isAdmin { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public EmployeesDTO() { }
        public EmployeesDTO(int id, string first, string last, string phone, int isadmin, string username, string password)
        {
            this.ID = id;
            this.FirstName = first;
            this.LastName = last;
            this.Phone = phone;
            this.isAdmin = isadmin;
            this.UserName = username;
            this.Password = password;
        }
    }
}
