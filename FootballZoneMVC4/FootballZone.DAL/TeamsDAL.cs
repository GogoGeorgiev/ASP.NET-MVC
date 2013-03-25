﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballZoneMVC4.DAL
{
    public static class TeamsDAL
    {
        public static List<Team> GetAllTeams()
        {
            FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

            return db.Teams.ToList();
        }

    }
}