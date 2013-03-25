using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCForum.Web.ViewModels
{
    public class ForumPostAnswerViewModel
    {
        
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime EditTime { get; set; }

    }
}