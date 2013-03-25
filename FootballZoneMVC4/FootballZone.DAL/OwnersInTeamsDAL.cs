using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballZoneMVC4.DAL
{
    public static class OwnersInTeamsDAL
    {
        public static List<OwnersTeam> GetAllOwnersInTeams(int id)
        {
            FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

            return db.OwnersTeams.Where(o => o.TeamID == id).ToList();
        
        }

    }
}
