using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballZoneMVC4.DAL
{
    public static class FootballMatchesDAL
    {
        public static List<FootballMatch> GetAllMatches()
        {
            FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

            return db.FootballMatches.ToList();
        
        }

    }
}
