using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCForum.Web.Models
{
    public class MVCForumDb : DbContext
    {
        public MVCForumDb() : base("DefaultConnection")
        { 
        
        }

        public DbSet<ForumCategory> ForumCategories { get; set; }
        public DbSet<ForumPostVote> ForumPostVotes { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<ForumPost> ForumPosts { get; set; }
        public DbSet<ForumPostAnswer> ForumPostAnswers { get; set; }

    }
}