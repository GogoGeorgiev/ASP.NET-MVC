using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballZoneMVC4.DAL
{
    public static class CoachesDAL
    {
        public static List<Coach> GetAllCoaches()
        {
            FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

            return db.Coaches.ToList();
        
        }
    }
}
