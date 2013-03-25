using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballZoneMVC4.DAL
{
   public static class StadiumsInTeamsDAL
    {
       public static List<StadiumsTeam> GetAllStadiumsInTeams(int id)
       {
           FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

           return db.StadiumsTeams.Where(s => s.TeamID == id).ToList();
       
       }

    }
}
