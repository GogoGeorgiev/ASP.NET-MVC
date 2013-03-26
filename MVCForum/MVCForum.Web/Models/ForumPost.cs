using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCForum.Web.Models
{
    public class ForumPost
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The title field is required.")]
        [MinLength(10)]
        [MaxLength(110)]
        [StringLength(110, MinimumLength = 10, ErrorMessage = "The title must be between 10 and 110 characters")]
        public string Title { get; set; }
        public string Content { get; set; }
        public UserProfile Author { get; set; }
        public DateTime CreationTime { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<ForumPostAnswer> Answer { get; set; }
    }
}