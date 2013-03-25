using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCForum.Web.Models
{
    public class ForumPostAnswer
    {
        public int Id { get; set; }
        public ForumPost ForumPost { get; set; }
        public string Content { get; set; }
        public UserProfile Author { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime EditTime { get; set; }

    }
}