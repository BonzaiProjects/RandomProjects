using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSDK
{
    public enum Quality
    {
        lowquality = 1,
        normal,
        superior,
        magic,
        set,
        rare,
        unique,
        crafted
    }
    public enum Class
    {
        normal,
        exceptionel,
        elite
    }
    public enum Flag
    {
        identified = 0x10,
        ethereal = 0x400000,
        runeword = 0x4000000
    }

    internal class Item : IItem
    {
        public string ItemID { get { return ItemID; } set { if (value.Length != 3) throw new Exception("ID is ALWAYS = 3 chars long"); ItemID = value; } }
        public string ItemName { get; set; }
        public int ItemQualityLevel { get; set; }
        public string ItemPicture { get; set; } // <-- fix me
        public Quality ItemQuality { get; set; }
        public Class ItemClass { get; set; }

        public Item(string idCode, string name, int itemQualityLevel, string itemPicture, Quality q, Class c)
        {
            this.ItemID = idCode.ToLower();
            this.ItemName = name;
            this.ItemQualityLevel = itemQualityLevel;
            this.ItemPicture = itemPicture;
            this.ItemQuality = q;
            this.ItemClass = c;
        }
    }
}
