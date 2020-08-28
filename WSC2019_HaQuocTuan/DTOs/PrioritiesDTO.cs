using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PrioritiesDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public PrioritiesDTO() { }
        public PrioritiesDTO(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}
