using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballZoneMVC4.DAL
{
    public static class OwnersDAL
    {
        public static List<Owner> GetAllOwners()
        {
            FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

            return db.Owners.ToList();
        
        }

    }
}
