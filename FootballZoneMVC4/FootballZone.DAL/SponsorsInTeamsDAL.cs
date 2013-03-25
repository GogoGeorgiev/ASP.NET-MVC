using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballZoneMVC4.DAL
{
    public static class SponsorsInTeamsDAL
    {
        public static List<SponsorsTeam> GetAllSponsorsInTeams(int id)
        {
            FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

            return db.SponsorsTeams.Where(s => s.TeamID == id).ToList();
        
        }

    }
}
