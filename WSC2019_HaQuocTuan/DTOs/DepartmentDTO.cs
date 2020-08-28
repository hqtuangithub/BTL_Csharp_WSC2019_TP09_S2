using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DepartmentDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public DepartmentDTO() { }
        public DepartmentDTO(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}
