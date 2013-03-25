using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCForum.Web.Models;

namespace MVCForum.Web.ViewModels
{
    public class ForumPostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public DateTime CreationTime { get; set; }
        public int Category { get; set; }
        public string CategoryName { get; set; }
        public int Rating { get; set; }
        public int Answers { get; set; }
    }
}