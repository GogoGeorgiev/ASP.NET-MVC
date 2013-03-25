using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballZoneMVC4.DAL
{
   public static  class PlayersDAL
    {
       public static List<Player> GetAllPlayers()
       {

           FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();
      
           return db.Players.ToList();
       }
       
    }
}
