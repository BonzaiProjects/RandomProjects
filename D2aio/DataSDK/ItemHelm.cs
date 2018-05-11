using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSDK
{
    class ItemHelm : Item
    {
        public int MinDef { get; set; }
        public int MaxDef { get; set; }
        public int MaxSockets { get; set; }
        public int Durability { get; set; }
        public int ReqStrength { get; set; }
        public int ReqLevel { get; set; }

        public ItemHelm(string idCode, string name, int itemQualityLevel, string itemPicture, Quality q, Class c, int minDef, int maxDef, int maxSockets, int durability, int reqStrength, int reqLevel) : base(idCode, name, itemQualityLevel, itemPicture, q, c)
        {
            this.MinDef = minDef;
            this.MaxDef = maxDef;
            this.MaxSockets = maxSockets;
            this.Durability = durability;
            this.ReqStrength = reqStrength;
            this.ReqLevel = reqLevel;
        }
    }
}
