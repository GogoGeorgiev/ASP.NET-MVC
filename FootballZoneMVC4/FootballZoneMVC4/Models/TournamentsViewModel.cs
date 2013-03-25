using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballZoneMVC4.Models
{
    public class TournamentsViewModel
    {
        public string Name { get; set; }
        public string Information { get; set; }
        public string ImageUrl { get; set; }
        public string Assosiation { get; set; }

        public TournamentsViewModel(string name, string information, string imageUrl, string association)
        {
            this.Name = name;
            this.Information = information;
            this.ImageUrl = imageUrl;
            this.Assosiation = association;
        }

    }


    }
