using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballZoneMVC4.DAL
{
   public static class TournamentsDAL
    {
       public static List<Tournament> GetAllTournaments()
       {
           FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

           return db.Tournaments.ToList();
       
       }

    }
}
