using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCForum.Web.ViewModels
{
    public class FullForumPostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public int Category { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreationTime { get; set; }
        public IEnumerable<ForumPostAnswerViewModel> Answers { get; set; }
        public int Rating { get; set; }
    }
}