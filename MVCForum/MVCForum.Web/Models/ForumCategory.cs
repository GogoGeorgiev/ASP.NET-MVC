using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCForum.Web.Models
{
    public class ForumCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}