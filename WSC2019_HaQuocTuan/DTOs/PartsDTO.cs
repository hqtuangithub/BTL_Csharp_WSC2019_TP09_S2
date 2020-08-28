using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PartsDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string EffectiveLife { get; set; }
        public PartsDTO() { }
        public PartsDTO(int id, string name, string effectivelife)
        {
            this.ID = id;
            this.Name = name;
            this.EffectiveLife = effectivelife;
        }
    }
}
