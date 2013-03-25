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
    public class AdminSponsorsInTeamsController : BasicAdminController
    {
        private FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

        //
        // GET: /Admin/AdminSponsorsInTeams/

        public ActionResult Index()
        {
            var sponsorsteams = db.SponsorsTeams.Include("Team").Include("Sponsor");
            return View(sponsorsteams.ToList());
        }

        //
        // GET: /Admin/AdminSponsorsInTeams/Details/5

        public ActionResult Details(int id = 0)
        {
            SponsorsTeam sponsorsteam = db.SponsorsTeams.Single(s => s.SponsorID == id);
            if (sponsorsteam == null)
            {
                return HttpNotFound();
            }
            return View(sponsorsteam);
        }

        //
        // GET: /Admin/AdminSponsorsInTeams/Create

        public ActionResult Create()
        {
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "Name");
            ViewBag.SponsorID = new SelectList(db.Sponsors, "SponsorID", "Name");
            return View();
        }

        //
        // POST: /Admin/AdminSponsorsInTeams/Create

        [HttpPost]
        public ActionResult Create(SponsorsTeam sponsorsteam)
        {
            if (ModelState.IsValid)
            {
                db.SponsorsTeams.AddObject(sponsorsteam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "Name", sponsorsteam.TeamID);
            ViewBag.SponsorID = new SelectList(db.Sponsors, "SponsorID", "Name", sponsorsteam.SponsorID);
            return View(sponsorsteam);
        }

        //
        // GET: /Admin/AdminSponsorsInTeams/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SponsorsTeam sponsorsteam = db.SponsorsTeams.Single(s => s.SponsorID == id);
            if (sponsorsteam == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "Name", sponsorsteam.TeamID);
            ViewBag.SponsorID = new SelectList(db.Sponsors, "SponsorID", "Name", sponsorsteam.SponsorID);
            return View(sponsorsteam);
        }

        //
        // POST: /Admin/AdminSponsorsInTeams/Edit/5

        [HttpPost]
        public ActionResult Edit(SponsorsTeam sponsorsteam)
        {
            if (ModelState.IsValid)
            {
                db.SponsorsTeams.Attach(sponsorsteam);
                db.ObjectStateManager.ChangeObjectState(sponsorsteam, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "Name", sponsorsteam.TeamID);
            ViewBag.SponsorID = new SelectList(db.Sponsors, "SponsorID", "Name", sponsorsteam.SponsorID);
            return View(sponsorsteam);
        }

        //
        // GET: /Admin/AdminSponsorsInTeams/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SponsorsTeam sponsorsteam = db.SponsorsTeams.Single(s => s.SponsorID == id);
            if (sponsorsteam == null)
            {
                return HttpNotFound();
            }
            return View(sponsorsteam);
        }

        //
        // POST: /Admin/AdminSponsorsInTeams/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SponsorsTeam sponsorsteam = db.SponsorsTeams.Single(s => s.SponsorID == id);
            db.SponsorsTeams.DeleteObject(sponsorsteam);
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