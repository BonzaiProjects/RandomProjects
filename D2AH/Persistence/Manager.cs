using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace Persistence
{
    public class Manager
    {
        public void CreateAuction(Item Item)
        {
            FakeDB.Auctions.Add(Item);
        }

        public Item ReadAuction()
        {
            Item found = null;
            foreach (var item in FakeDB.Auctions)
            {
                if (true)
                {

                }
            }
            return found;
        }

        public void UpdateAuction()
        {

        }

        public void DeleteAuction()
        {

        }
    }
}
