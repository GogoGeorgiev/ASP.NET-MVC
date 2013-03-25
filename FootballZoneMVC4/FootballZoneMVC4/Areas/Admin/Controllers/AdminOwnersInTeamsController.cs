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
    public class AdminOwnersInTeamsController : BasicAdminController
    {
        private FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

        //
        // GET: /Admin/AdminOwnersInTeams/

        public ActionResult Index()
        {
            var ownersteams = db.OwnersTeams.Include("Team").Include("Owner");
            return View(ownersteams.ToList());
        }

        //
        // GET: /Admin/AdminOwnersInTeams/Details/5

        public ActionResult Details(int id = 0)
        {
            OwnersTeam ownersteam = db.OwnersTeams.Single(o => o.OwnerID == id);
            if (ownersteam == null)
            {
                return HttpNotFound();
            }
            return View(ownersteam);
        }

        //
        // GET: /Admin/AdminOwnersInTeams/Create

        public ActionResult Create()
        {
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "Name");
            ViewBag.OwnerID = new SelectList(db.Owners, "OwnerID", "OwnerNames");
            return View();
        }

        //
        // POST: /Admin/AdminOwnersInTeams/Create

        [HttpPost]
        public ActionResult Create(OwnersTeam ownersteam)
        {
            if (ModelState.IsValid)
            {
                db.OwnersTeams.AddObject(ownersteam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "Name", ownersteam.TeamID);
            ViewBag.OwnerID = new SelectList(db.Owners, "OwnerID", "OwnerNames", ownersteam.OwnerID);
            return View(ownersteam);
        }

        //
        // GET: /Admin/AdminOwnersInTeams/Edit/5

        public ActionResult Edit(int id = 0)
        {
            OwnersTeam ownersteam = db.OwnersTeams.Single(o => o.OwnerID == id);
            if (ownersteam == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "Name", ownersteam.TeamID);
            ViewBag.OwnerID = new SelectList(db.Owners, "OwnerID", "OwnerNames", ownersteam.OwnerID);
            return View(ownersteam);
        }

        //
        // POST: /Admin/AdminOwnersInTeams/Edit/5

        [HttpPost]
        public ActionResult Edit(OwnersTeam ownersteam)
        {
            if (ModelState.IsValid)
            {
                db.OwnersTeams.Attach(ownersteam);
                db.ObjectStateManager.ChangeObjectState(ownersteam, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "Name", ownersteam.TeamID);
            ViewBag.OwnerID = new SelectList(db.Owners, "OwnerID", "OwnerNames", ownersteam.OwnerID);
            return View(ownersteam);
        }

        //
        // GET: /Admin/AdminOwnersInTeams/Delete/5

        public ActionResult Delete(int id = 0)
        {
            OwnersTeam ownersteam = db.OwnersTeams.Single(o => o.OwnerID == id);
            if (ownersteam == null)
            {
                return HttpNotFound();
            }
            return View(ownersteam);
        }

        //
        // POST: /Admin/AdminOwnersInTeams/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            OwnersTeam ownersteam = db.OwnersTeams.Single(o => o.OwnerID == id);
            db.OwnersTeams.DeleteObject(ownersteam);
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