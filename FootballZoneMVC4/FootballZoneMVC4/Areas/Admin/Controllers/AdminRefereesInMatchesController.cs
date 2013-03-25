using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballZoneMVC4.DAL;

namespace FootballZoneMVC4.Areas.Admin.Controllers
{
    public class AdminRefereesInMatchesController : BasicAdminController
    {
        private FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

        //
        // GET: /Admin/AdminRefereesInMatches/

        public ActionResult Index()
        {
            var refereesmatches = db.RefereesMatches.Include("FootballMatch").Include("Referee");
            return View(refereesmatches.ToList());
        }

        //
        // GET: /Admin/AdminRefereesInMatches/Details/5

        public ActionResult Details(int id = 0)
        {
            RefereesMatch refereesmatch = db.RefereesMatches.Single(r => r.MatchID == id);
            if (refereesmatch == null)
            {
                return HttpNotFound();
            }
            return View(refereesmatch);
        }

        //
        // GET: /Admin/AdminRefereesInMatches/Create

        public ActionResult Create()
        {
            ViewBag.MatchID = new SelectList(db.FootballMatches, "MatchID", "MatchID");
            ViewBag.RefereeID = new SelectList(db.Referees, "RefereeID", "RefereeNames");
            return View();
        }

        //
        // POST: /Admin/AdminRefereesInMatches/Create

        [HttpPost]
        public ActionResult Create(RefereesMatch refereesmatch)
        {
            if (ModelState.IsValid)
            {
                db.RefereesMatches.AddObject(refereesmatch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MatchID = new SelectList(db.FootballMatches, "MatchID", "MatchID", refereesmatch.MatchID);
            ViewBag.RefereeID = new SelectList(db.Referees, "RefereeID", "RefereeNames", refereesmatch.RefereeID);
            return View(refereesmatch);
        }

        //
        // GET: /Admin/AdminRefereesInMatches/Edit/5

        public ActionResult Edit(int id = 0)
        {
            RefereesMatch refereesmatch = db.RefereesMatches.Single(r => r.MatchID == id);
            if (refereesmatch == null)
            {
                return HttpNotFound();
            }
            ViewBag.MatchID = new SelectList(db.FootballMatches, "MatchID", "MatchID", refereesmatch.MatchID);
            ViewBag.RefereeID = new SelectList(db.Referees, "RefereeID", "RefereeNames", refereesmatch.RefereeID);
            return View(refereesmatch);
        }

        //
        // POST: /Admin/AdminRefereesInMatches/Edit/5

        [HttpPost]
        public ActionResult Edit(RefereesMatch refereesmatch)
        {
            if (ModelState.IsValid)
            {
                db.RefereesMatches.Attach(refereesmatch);
                db.ObjectStateManager.ChangeObjectState(refereesmatch, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MatchID = new SelectList(db.FootballMatches, "MatchID", "MatchID", refereesmatch.MatchID);
            ViewBag.RefereeID = new SelectList(db.Referees, "RefereeID", "RefereeNames", refereesmatch.RefereeID);
            return View(refereesmatch);
        }

        //
        // GET: /Admin/AdminRefereesInMatches/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RefereesMatch refereesmatch = db.RefereesMatches.Single(r => r.MatchID == id);
            if (refereesmatch == null)
            {
                return HttpNotFound();
            }
            return View(refereesmatch);
        }

        //
        // POST: /Admin/AdminRefereesInMatches/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            RefereesMatch refereesmatch = db.RefereesMatches.Single(r => r.MatchID == id);
            db.RefereesMatches.DeleteObject(refereesmatch);
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