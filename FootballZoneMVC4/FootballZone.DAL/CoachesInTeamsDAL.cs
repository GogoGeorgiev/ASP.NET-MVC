using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballZoneMVC4.DAL
{
    public static class CoachesInTeamsDAL
    {
        public static List<CoachesTeam> GetAllCoachesInTeams(int id)
        {
            FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

            return db.CoachesTeams.Where(c => c.TeamID == id).ToList();
        
        }

    }
}
