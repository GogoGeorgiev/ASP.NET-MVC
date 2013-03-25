using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballZoneMVC4.DAL
{
    public static class TeamDetailsDAL
    {
        public static List<Stadium> GetTeamStadium()
        {
            FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

            return db.Stadiums.ToList();

        }

        public static List<Coach> GetTeamCoach()
        {
            FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

            return db.Coaches.ToList();

        }

        public static List<Sponsor> GetTeamSponsor()
        {
            FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

            return db.Sponsors.ToList();

        }

        public static List<Owner> GetTeamOwner()
        {
            FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

            return db.Owners.ToList();

        }


    }
}
