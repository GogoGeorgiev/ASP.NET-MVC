using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballZoneMVC4.Models
{
    public class PlayersViewModel
    {
        private string p;
        private string p_2;
        private byte[] p_3;

        public string PlayerNames { get; set; }
        public string Biography { get; set; }
        public string ImageUrl { get; set; }

        public PlayersViewModel(string playerNames, string biography, string imageUrl)
        {
            this.PlayerNames = playerNames;
            this.Biography = biography;
            this.ImageUrl = imageUrl;
        
        }

        public PlayersViewModel(string p, string p_2, byte[] p_3)
        {
            // TODO: Complete member initialization
            this.p = p;
            this.p_2 = p_2;
            this.p_3 = p_3;
        }


    }
}