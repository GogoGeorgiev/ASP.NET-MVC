using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FootballZoneMVC4.Models
{
    public class SponsorsViewModel
    {

        [Required]
        public string Name { get; set; }

        public string Information { get; set; }

        public string ImageUrl { get; set; }

        public SponsorsViewModel(string name, string information, string imageUrl)
        {
            this.Name = name;
            this.Information = information;
            this.ImageUrl = imageUrl;
            
        }

    }
}