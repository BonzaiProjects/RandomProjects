using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSDK
{
    public interface IItem
    {
        string ItemID { get; set; }
        string ItemName { get; set; }
        int ItemQualityLevel { get; set; }
        string ItemPicture { get; set; }
    }
}
