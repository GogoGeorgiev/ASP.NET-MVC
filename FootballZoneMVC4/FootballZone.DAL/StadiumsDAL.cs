using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballZoneMVC4.DAL
{
    public static class StadiumsDAL
    {
      
        public static List<Stadium> GetAllStadiums()
        {
            FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

            return db.Stadiums.ToList();
        
        }

    }
}
