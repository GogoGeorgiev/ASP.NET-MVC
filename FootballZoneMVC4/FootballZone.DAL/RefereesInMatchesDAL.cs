using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballZoneMVC4.DAL
{
    public static class RefereesInMatchesDAL
    {
        public static List<RefereesMatch> GetAllRefereesInMatches(int id)
        {
            FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

            return db.RefereesMatches.Where(m => m.MatchID == id).ToList();
        
        }

    }
}
