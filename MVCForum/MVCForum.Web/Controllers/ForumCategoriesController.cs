using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCForum.Web.Models;
using MVCForum.Web.ViewModels;
using PagedList;

namespace MVCForum.Web.Controllers
{
    
    public class ForumCategoriesController : Controller
    {
        private MVCForumDb db = new MVCForumDb();

        //
        // GET: /Categories/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.ForumCategories.ToList());
        }

        public ActionResult ViewCategories(int page = 1)
        {
            var category = db.ForumCategories
                .OrderBy(y => y.Id)
                .Select(x => new ForumCategoryViewModel { 
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description
                }).ToPagedList(page, 10);

            return View(category);
        }

        //
        // GET: /Categories/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Categories/Create

        [HttpPost]
        public ActionResult Create(ForumCategory forumpostcategory)
        {
            if (ModelState.IsValid)
            {
                db.ForumCategories.Add(forumpostcategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(forumpostcategory);
        }

        //
        // GET: /Categories/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id = 0)
        {
            ForumCategory forumpostcategory = db.ForumCategories.Find(id);
            if (forumpostcategory == null)
            {
                return HttpNotFound();
            }
            return View(forumpostcategory);
        }

        //
        // POST: /Categories/Edit/5

        [HttpPost]
        public ActionResult Edit(ForumCategory forumpostcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forumpostcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(forumpostcategory);
        }

        //
        // GET: /Categories/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id = 0)
        {
            ForumCategory forumpostcategory = db.ForumCategories.Find(id);
            if (forumpostcategory == null)
            {
                return HttpNotFound();
            }
            return View(forumpostcategory);
        }

        //
        // POST: /Categories/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ForumCategory forumpostcategory = db.ForumCategories.Find(id);
            db.ForumCategories.Remove(forumpostcategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}