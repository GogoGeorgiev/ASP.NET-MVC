using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballZoneMVC4.Models
{
    public class CoachesViewModel
    {
        public string CoachNames { get; set; }
        public string Biography { get; set; }
        public string ImageUrl { get; set; }

        public CoachesViewModel(string coachNames, string biography, string imageUrl)
        {
            this.CoachNames = coachNames;
            this.Biography = biography;
            this.ImageUrl = imageUrl;
        
        }
    }
}