using System;
using System.Collections.Generic;
using System.Text;
using UserManager;
using Persistence;
using Domain;

namespace AuctionHouse
{
    class AuctionHouse
    {
        void CreateAuctions(User Seller, List<Item> Items)
        {
            foreach (Item item in Items)
            {
                CreateAuction(Seller, item);
            }
        }

        void CreateAuction(User Seller, Item Item)
        {

        }

        void GetUserAuctions(User User)
        {

        }
    }
}
