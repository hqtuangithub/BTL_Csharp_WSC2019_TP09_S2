using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALs;
using DTOs;

namespace BULs
{
    public class PrioritiesBUL
    {
        public List<PrioritiesDTO> PrioritiyShow()
        {
            PrioritiesDAL priorities = new PrioritiesDAL();
            return priorities.PrioritiyShow();
        }
    }
}
