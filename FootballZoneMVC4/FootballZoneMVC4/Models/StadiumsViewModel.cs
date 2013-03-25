﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballZoneMVC4.Models
{
    public class StadiumsViewModel
    {
        public string Name { get; set; }
        public string Information { get; set; }
        public string ImageUrl { get; set; }

        public StadiumsViewModel(string name, string information, string imageUrl)
        {
            this.Name = name;
            this.Information = information;
            this.ImageUrl = imageUrl;
        }

    }
}