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
    public class AdminCoachesInTeamsController : BasicAdminController
    {
        private FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

        //
        // GET: /Admin/AdminCoachesInTeams/

        public ActionResult Index()
        {
            var coachesteams = db.CoachesTeams.Include("Team").Include("Coach");
            return View(coachesteams.ToList());
        }

        //
        // GET: /Admin/AdminCoachesInTeams/Details/5

        public ActionResult Details(int id = 0)
        {
            CoachesTeam coachesteam = db.CoachesTeams.Single(c => c.CoachID == id);
            if (coachesteam == null)
            {
                return HttpNotFound();
            }
            return View(coachesteam);
        }

        //
        // GET: /Admin/AdminCoachesInTeams/Create

        public ActionResult Create()
        {
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "Name");
            ViewBag.CoachID = new SelectList(db.Coaches, "CoachID", "CoachNames");
            return View();
        }

        //
        // POST: /Admin/AdminCoachesInTeams/Create

        [HttpPost]
        public ActionResult Create(CoachesTeam coachesteam)
        {
            if (ModelState.IsValid)
            {
                db.CoachesTeams.AddObject(coachesteam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "Name", coachesteam.TeamID);
            ViewBag.CoachID = new SelectList(db.Coaches, "CoachID", "CoachNames", coachesteam.CoachID);
            return View(coachesteam);
        }

        //
        // GET: /Admin/AdminCoachesInTeams/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CoachesTeam coachesteam = db.CoachesTeams.Single(c => c.CoachID == id);
            if (coachesteam == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "Name", coachesteam.TeamID);
            ViewBag.CoachID = new SelectList(db.Coaches, "CoachID", "CoachNames", coachesteam.CoachID);
            return View(coachesteam);
        }

        //
        // POST: /Admin/AdminCoachesInTeams/Edit/5

        [HttpPost]
        public ActionResult Edit(CoachesTeam coachesteam)
        {
            if (ModelState.IsValid)
            {
                db.CoachesTeams.Attach(coachesteam);
                db.ObjectStateManager.ChangeObjectState(coachesteam, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "Name", coachesteam.TeamID);
            ViewBag.CoachID = new SelectList(db.Coaches, "CoachID", "CoachNames", coachesteam.CoachID);
            return View(coachesteam);
        }

        //
        // GET: /Admin/AdminCoachesInTeams/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CoachesTeam coachesteam = db.CoachesTeams.Single(c => c.CoachID == id);
            if (coachesteam == null)
            {
                return HttpNotFound();
            }
            return View(coachesteam);
        }

        //
        // POST: /Admin/AdminCoachesInTeams/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CoachesTeam coachesteam = db.CoachesTeams.Single(c => c.CoachID == id);
            db.CoachesTeams.DeleteObject(coachesteam);
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