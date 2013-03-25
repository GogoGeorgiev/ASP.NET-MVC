using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballZoneMVC4.Models
{
    public class CoachesInTeamsViewModel
    {
        public string Coach { get; set; }
        public string ImageUrl { get; set; }
        public string Team { get; set; }
        public string Information { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string CoachKind { get; set; }

        public CoachesInTeamsViewModel(string coach, string team, string imageUrl, string information,
                                        DateTime fromDate, DateTime toDate, string coachKind)
        {
            
            this.Coach = coach;
            this.Team = team;
            this.ImageUrl = imageUrl;
            this.Information = information;
            this.FromDate = fromDate;
            this.ToDate = toDate;
            this.CoachKind = coachKind;
        
        }


    }
}