using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FootballZoneMVC4.DAL;

namespace FootballZoneMVC4.Models
{
    public class TeamsViewModel
    {
        
        public int ID { get; set; }
        public string  Name { get; set; }
        public string  Biography { get; set; }
        public string  Country { get; set; }
        public string ImageUrl { get; set; }
        
       
        
        public TeamsViewModel(int id, string name, string biography, string country,
             string imageUrl)
        {
            this.ID = id;
            this.Name = name;
            this.Biography = biography;
            this.Country = country;
            this.ImageUrl = imageUrl;
           
       
        }

       
    }
}