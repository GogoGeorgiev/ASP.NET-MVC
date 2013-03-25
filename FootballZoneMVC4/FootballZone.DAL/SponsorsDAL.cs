using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballZoneMVC4.DAL
{
   public static class SponsorsDAL
    {
       public static List<Sponsor> GetAllSponsors()
       {
           FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

           return db.Sponsors.ToList();
       }

    }
}
