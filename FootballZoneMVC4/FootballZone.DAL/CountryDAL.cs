﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballZoneMVC4.DAL
{
    public static class CountryDAL
    {
        public static List<Country> GetAllCountries()
        {
            FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

            return db.Countries.ToList();
        
        }

    }
}