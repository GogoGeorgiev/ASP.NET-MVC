using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballZoneMVC4.DAL
{
    public static class PlayersTeamsDAL
    {
        public static List<PlayersTeam> GetAllPlayersInTeams(int id)
        {
            FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

            return db.PlayersTeams.Where(p => p.TeamID == id ).ToList();

        }

    }
}
