using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballZoneMVC4.Models
{
    public class RefereeInMatchesViewModel
    {
      
        public string Referee { get; set; }
        public string ImageUrl { get; set; }
        public string RefInformation { get; set; }
        public string FootballMatchInfo { get; set; }
        public string RefereeKind { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public string FinalScore { get; set; }
        public DateTime Date { get; set; }
        public string TeamAImage { get; set; }
        public string TeamBImage { get; set; }
        public string Tournament { get; set; }

        public RefereeInMatchesViewModel(string referee, string imageUrl, string refInformation, string refereeKind,
                                           string footabllMatchInfo, string teamA, string teamB, string finalScore,
                                            DateTime date, string teamAimg, string teamBimg, string tournament)
        {
            this.Referee = referee;
            this.ImageUrl = imageUrl;
            this.RefInformation = refInformation;
            this.RefereeKind = refereeKind;
            this.FootballMatchInfo = footabllMatchInfo;
            this.TeamA = teamA;
            this.TeamB = teamB;
            this.FinalScore = finalScore;
            this.Date = date;
            this.TeamAImage = teamAimg;
            this.TeamBImage = teamBimg;
            this.Tournament = tournament;
        }

       

    


    }
}