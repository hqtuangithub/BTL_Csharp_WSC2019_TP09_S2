using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ListAvailableAssetDTO
    {
        public string AssetSN { get; set; }
        public string AssetName { get; set; }
        public string EMEndDate { get; set; }
        public int  Amount { get; set; }

        public ListAvailableAssetDTO() { }
        public ListAvailableAssetDTO(string assetsn, string assetname, string enddate, int amount)
        {
            this.AssetSN = assetsn;
            this.AssetName = assetname;
            this.EMEndDate = enddate;
            this.Amount = amount;
        }
        public ListAvailableAssetDTO(string assetsn, string assetname)
        {
            this.AssetSN = assetsn;
            this.AssetName = assetname;
        }
    }
}
