using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.DateTime;

namespace FootballZoneMVC4.Models
{
    public class SponsorsInTeamsViewModel
    {
        public string Sponsor { get; set; }
        public string ImageUrl { get; set; }
        public string Team { get; set; }
        public string Information { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        
    
        public SponsorsInTeamsViewModel(string sponsor, string team, string imageUrl, string information,
                                        DateTime fromDate, DateTime toDate)
        {
            
            this.Sponsor = sponsor;
            this.Team = team;
            this.ImageUrl = imageUrl;
            this.Information = information;
            this.FromDate = fromDate;
            this.ToDate = toDate;
           
        
        }

    }
}