using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballZoneMVC4.DAL
{
    public static class FootballAssociationsDAL
    {
        public static List<FootballAssociation> GetAllAssociations()
        {
            FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

            return db.FootballAssociations.ToList();
        
        }

    }
}
