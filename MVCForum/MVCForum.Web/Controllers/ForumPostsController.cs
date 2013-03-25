using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCForum.Web.Filters;
using MVCForum.Web.Models;
using MVCForum.Web.ViewModels;
using WebMatrix.WebData;
using PagedList;

namespace MVCForum.Web.Controllers
{
    public class ForumPostsController : Controller
    {
        public MVCForumDb _db = new MVCForumDb();

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_db.ForumCategories, "Id", "Title");
            return View();
        }

        [Authorize]
        [HttpPost]
        [InitializeSimpleMembership]
        public ActionResult Create(ForumPost forumPost)
        {
            var user = _db.UserProfiles.FirstOrDefault(x => x.UserId == WebSecurity.CurrentUserId);
            ViewBag.CategoryId = new SelectList(_db.ForumCategories, "Id", "Title", forumPost.CategoryId);
            var post = new ForumPost
            {
                Content = Server.HtmlDecode(forumPost.Content),
                CategoryId = forumPost.CategoryId,
                CreationTime = DateTime.Now,
                Title = forumPost.Title,
                Author = user
            };

            _db.ForumPosts.Add(post);
            _db.SaveChanges();
            return Redirect("/");
        }

        public ActionResult ViewPost(int postId)
        {
            if (!_db.ForumPosts.Any(x => x.Id == postId))
	        {
                Redirect("/");
	        }

            var post = _db.ForumPosts.Where(x => x.Id == postId)
                .Select(x => new FullForumPostViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    Category = x.CategoryId,
                    CategoryName = _db.ForumCategories.FirstOrDefault(z => z.Id == x.CategoryId).Title,
                    CreationTime = x.CreationTime,
                    UserId = x.Author.UserId,
                    UserName = x.Author.UserName,
                    Rating =
                       _db.ForumPostVotes.Count(y => y.Post.Id == x.Id && y.IsUpVote) -
                       _db.ForumPostVotes.Count(y => y.Post.Id == x.Id && !y.IsUpVote)
                }).SingleOrDefault();

            post.Answers = _db.ForumPostAnswers.Where(a => a.ForumPost.Id == postId)
                   .Select(y => new ForumPostAnswerViewModel
                   {
                       Id = y.Id,
                       Content = y.Content,
                       CreationTime = y.CreationTime,
                       EditTime = y.EditTime,
                       UserName = y.Author.UserName,
                       UserId = y.Author.UserId
                   });

            return View(post);
        }

        [Authorize]
        [HttpPost]
        [InitializeSimpleMembership]
        public ActionResult DoAnswer(int forumPostId, string content, int page = 1 )
        {
            var user = _db.UserProfiles.FirstOrDefault(x => x.UserId == WebSecurity.CurrentUserId);
            var forumPost = _db.ForumPosts.FirstOrDefault(x => x.Id == forumPostId);
            //add to database
            _db.ForumPostAnswers
                .Add(new ForumPostAnswer() 
            { 
                Author = user,
                Content = Server.HtmlDecode(content),
                CreationTime = DateTime.Now,
                EditTime = DateTime.Now,
                ForumPost = forumPost,
            });

            _db.SaveChanges(); 

            return Redirect("/Questions/" + forumPostId);
        }

        [Authorize]
        [InitializeSimpleMembership]
        public ActionResult VoteUp(int id)
        {
            return Vote(id, true);
        }

        [Authorize]
        [InitializeSimpleMembership]
        public ActionResult VoteDown(int id)
        {
            return Vote(id, false);

        }

        private ActionResult Vote(int id, bool upVote)
        {
            if (_db.ForumPostVotes.Any(x => x.Post.Id == id && x.User.UserId == WebSecurity.CurrentUserId))
            {
                var currentEntry = _db.ForumPostVotes.SingleOrDefault(x => x.Post.Id == id && x.User.UserId == WebSecurity.CurrentUserId);
                if (currentEntry.IsUpVote == upVote)
                {
                    _db.ForumPostVotes.Remove(currentEntry);
                    _db.SaveChanges();
                }
                else
                {
                    currentEntry.IsUpVote = upVote;
                    _db.SaveChanges();
                }
            }
            else
            {
                var user = _db.UserProfiles.FirstOrDefault(x => x.UserId == WebSecurity.CurrentUserId);
                var forumPost = _db.ForumPosts.FirstOrDefault(x => x.Id == id);

                _db.ForumPostVotes.Add(new ForumPostVote()
                {
                    Post = forumPost,
                    User = user,
                    IsUpVote = upVote
                });
                _db.SaveChanges();
            }

            int rating = _db.ForumPostVotes.Count(y => y.Post.Id == id && y.IsUpVote) -
                         _db.ForumPostVotes.Count(y => y.Post.Id == id && !y.IsUpVote);

            return Content(rating.ToString());
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
