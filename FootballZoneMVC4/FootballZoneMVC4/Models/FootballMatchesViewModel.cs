using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballZoneMVC4.Models
{
    public class FootballMatchesViewModel
    {
        public int ID { get; set; }
        public string TournamentID { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public string FinalScore { get; set; }
        public DateTime MatchDate { get; set; }
        public string Information { get; set; }

        public FootballMatchesViewModel(int id, string tournamentID, string teamA, string teamB,
                                string finalScore, DateTime matchDate, string information)
        {
            this.ID = id;
            this.TournamentID = tournamentID;
            this.TeamA = teamA;
            this.TeamB = teamB;
            this.FinalScore = finalScore;
            this.MatchDate = matchDate;
            this.Information = information;
        
        }


    }
}