using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCForum.Web.Models;
using MVCForum.Web.ViewModels;
using PagedList;

namespace MVCForum.Web.Controllers
{
    public class HomeController : Controller
    {
        public MVCForumDb _db = new MVCForumDb();

        public ActionResult Index(string searchTerm = null, int page = 1)
        {
         
            //Get the last 15 forum posts
            var latestForumPosts = _db.ForumPosts
                .Where(x => searchTerm == null || x.Title.Contains(searchTerm))
                .OrderByDescending(x => x.CreationTime)
                .Select(x => new ForumPostViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Category = x.CategoryId,
                    CategoryName = _db.ForumCategories.FirstOrDefault(z => z.Id == x.CategoryId).Title,
                    UserName = x.Author.UserName,
                    UserId = x.Author.UserId,
                    CreationTime = x.CreationTime,
                    Answers = _db.ForumPostAnswers.Count(c => c.ForumPost.Id == x.Id),
                    Rating =
                        _db.ForumPostVotes.Count(y => y.Post.Id == x.Id && y.IsUpVote) -
                        _db.ForumPostVotes.Count(y => y.Post.Id == x.Id && !y.IsUpVote)
                    
                }).ToPagedList(page, 15);


            if (Request.IsAjaxRequest())
            {
                return PartialView("_Posts", latestForumPosts);
            }

            //Pass data to View to show 
            return View(latestForumPosts);
        }

        public ActionResult Category(int id, int page = 1)
        {
            
            //Get the last 15 categories
            var category = _db.ForumPosts
                .Where(x => x.CategoryId == id)
                .OrderByDescending(x => x.CreationTime)
                .Select(x => new ForumPostViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Category = x.CategoryId,
                    CategoryName = _db.ForumCategories.FirstOrDefault(z => z.Id == x.CategoryId).Title,
                    UserName = x.Author.UserName,
                    UserId = x.Author.UserId,
                    CreationTime = x.CreationTime,
                    Rating =
                        _db.ForumPostVotes.Count(y => y.Post.Id == x.Id && y.IsUpVote) -
                        _db.ForumPostVotes.Count(y => y.Post.Id == x.Id && !y.IsUpVote)
                }).ToPagedList(page, 15);

            //Pass data to View to show 
            return View(category);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        //Release the connection from Database, when we are done
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
