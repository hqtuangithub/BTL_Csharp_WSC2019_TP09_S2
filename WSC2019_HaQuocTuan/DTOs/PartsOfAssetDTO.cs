using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PartsOfAssetDTO
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }

        public PartsOfAssetDTO() { }
        public PartsOfAssetDTO(string name, decimal amount) 
        {
            this.Name = name;
            this.Amount = amount;
        }

    }
}
