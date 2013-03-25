using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballZoneMVC4.DAL
{
    public static class RefereesDAL
    {
        public static List<Referee> GetAllReferees()
        {
            FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

            return db.Referees.ToList();
        
        }


    }
}
