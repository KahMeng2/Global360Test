using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global360Test.Models
{   
    enum assetStatus
    {
        Pending,
        Ready_to_Deploy,
        Archived,
        Broken,
        Lost_or_Stolen,
        Out_for_Diagnostics,
        Out_for_Repair
    }
    internal class Asset
    {
        private string assetTag { get; set; }
        private assetStatus status { get; set; }

        private string checkoutTo { get; set; }

        // Model would be an enum since it has a fixed limit of models but for simplicity, it's a string here
        private string model { get; set; }

        // Asset tag is taken from the page after creation
        public Asset(assetStatus status, string checkoutTo, string model)
        {
            this.assetTag = "";
            this.status = status;
            this.checkoutTo = checkoutTo;
            this.model = model;
        }

        public void SetAssetTag(string tag)
        {
            this.assetTag = tag;
        }

        public void SetCheckoutTo(string checkoutTo)
        {
            this.checkoutTo = checkoutTo;
        }

        public string getModel()
        {
            return this.model;
        }

        public assetStatus getStatus()
        {
            return this.status;
        }
        
        public string getCheckoutTo()
        {
            return this.checkoutTo;
        }

        public string getAssetTag()
        {
            return this.assetTag;
        }

    }
}
