using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballZoneMVC4.Models
{
    public class PlayersInTeamsViewModel
    {
        public string Player { get; set; }
        public string ImageUrl { get; set; }
        public string Team { get; set; }
        public string Information { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string PlayerKind { get; set; }

        public PlayersInTeamsViewModel(string player, string team, string imageUrl, string information,
                                        DateTime fromDate, DateTime toDate, string playerKind)
        {
            
            this.Player = player;
            this.Team = team;
            this.ImageUrl = imageUrl;
            this.Information = information;
            this.FromDate = fromDate;
            this.ToDate = toDate;
            this.PlayerKind = playerKind;
        
        }

    }
}