using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Item
    {
        public int AuctionID;
        public string ItemID;
        public Type Type;
        public Quality Quality;
        public string Name;
        public int Sockets;
        public bool Ethereal;
        public bool Unidentified;
        // Screenshot

        public Item(int AuctionID, string ItemID, Type Type, Quality Quality, string Name, int Sockets, bool Ethereal, bool Unidentified)
        {
            this.AuctionID = AuctionID;
            this.ItemID = ItemID;
            this.Type = Type;
            this.Quality = Quality;
            this.Name = Name;
            this.Sockets = Sockets;
            this.Ethereal = Ethereal;
            this.Unidentified = Unidentified;
        }
    }

    public enum Type
    {
        LowQuality, // Low Quality, Cracked, Crude, Damaged 
        Normal,
        Superior,
        Magic,
        Rare,
        Set,
        Unique,
        Runeword,
        Crafted
    }

    public enum Quality
    {
        Normal,
        Exceptional,
        Elite
    }

    public enum Realm
    {
        West,
        East,
        Asia,
        Europe
    }
}
