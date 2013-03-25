using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FootballZoneMVC4.Models;

namespace FootballZoneMVC4.ViewModels
{
    public class FootballViewModel
    {
        
        public List<TeamsViewModel> Teams { get; set; }
        public List<PlayersInTeamsViewModel> Players { get; set; }

        public FootballViewModel(List<TeamsViewModel> _teams, List<PlayersInTeamsViewModel> _players)
        {
            this.Teams = _teams;
            this.Players = _players;
        
        }


    }
}