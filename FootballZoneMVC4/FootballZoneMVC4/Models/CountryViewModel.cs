using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballZoneMVC4.Models
{
    public class CountryViewModel
    {
        public int CountryID { get; set; }
        public string  Name { get; set; }
        public string ImageUrl { get; set; }

        public CountryViewModel(int id, string name, string imageUrl)
        {
            this.CountryID = id;
            this.Name = name;
            this.ImageUrl = imageUrl;
        
        }

    }
}