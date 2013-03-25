using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCForum.Web.Filters;
using MVCForum.Web.Models;
using MVCForum.Web.ViewModels;
using PagedList;
using WebMatrix.WebData;

namespace MVCForum.Web.Controllers
{
    public class ForumUsersController : Controller
    {
        private MVCForumDb _db = new MVCForumDb();

        public ActionResult ViewUsers(int page = 1) 
        {
            var user = _db.UserProfiles
                .OrderByDescending(y => y.UserId)
                .Select(x => new ForumUserViewModel 
                { 
                  Id = x.UserId,
                  Name = x.UserName
                }).ToPagedList(page, 24);

            return View(user);
        }

        public ActionResult UserProfile(int id)
        {
            UserProfile userprofile = _db.UserProfiles.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}