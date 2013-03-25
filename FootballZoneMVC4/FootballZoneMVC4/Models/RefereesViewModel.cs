using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballZoneMVC4.Models
{
    public class RefereesViewModel
    {
        public string RefereeNames { get; set; }
        public string Biography { get; set; }
        public string ImageUrl { get; set; }

        public RefereesViewModel(string refereeNames, string biography, string imageUrl)
        {
            this.RefereeNames = refereeNames;
            this.Biography = biography;
            this.ImageUrl = imageUrl;
        
        }

    }
}