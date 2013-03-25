using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballZoneMVC4.Models
{
    public class OwnersViewModel
    {
        public string OwnerNames { get; set; }
        public string Biography { get; set; }
        public string ImageUrl { get; set; }

        public OwnersViewModel(string ownerNames, string biography, string imageUrl)
        {
            this.OwnerNames = ownerNames;
            this.Biography = biography;
            this.ImageUrl = imageUrl;
        
        }

    }
}