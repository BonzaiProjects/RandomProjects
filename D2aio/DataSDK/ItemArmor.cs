using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSDK
{
    class ItemArmor : IItem
    {
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public int ItemQualityLevel { get; set; }
        public string ItemPicture { get; set; }
    }
}
