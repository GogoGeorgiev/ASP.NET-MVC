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
    public class AdminStadiumsInTeamsController : BasicAdminController
    {
        private FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

        //
        // GET: /Admin/AdminStadiumsInTeams/

        public ActionResult Index()
        {
            var stadiumsteams = db.StadiumsTeams.Include("Stadium").Include("Team");
            return View(stadiumsteams.ToList());
        }

        //
        // GET: /Admin/AdminStadiumsInTeams/Details/5

        public ActionResult Details(int id = 0)
        {
            StadiumsTeam stadiumsteam = db.StadiumsTeams.Single(s => s.StadiumID == id);
            if (stadiumsteam == null)
            {
                return HttpNotFound();
            }
            return View(stadiumsteam);
        }

        //
        // GET: /Admin/AdminStadiumsInTeams/Create

        public ActionResult Create()
        {
            ViewBag.StadiumID = new SelectList(db.Stadiums, "StadiumID", "Name");
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "Name");
            return View();
        }

        //
        // POST: /Admin/AdminStadiumsInTeams/Create

        [HttpPost]
        public ActionResult Create(StadiumsTeam stadiumsteam)
        {
            if (ModelState.IsValid)
            {
                db.StadiumsTeams.AddObject(stadiumsteam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StadiumID = new SelectList(db.Stadiums, "StadiumID", "Name", stadiumsteam.StadiumID);
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "Name", stadiumsteam.TeamID);
            return View(stadiumsteam);
        }

        //
        // GET: /Admin/AdminStadiumsInTeams/Edit/5

        public ActionResult Edit(int id = 0)
        {
            StadiumsTeam stadiumsteam = db.StadiumsTeams.Single(s => s.StadiumID == id);
            if (stadiumsteam == null)
            {
                return HttpNotFound();
            }
            ViewBag.StadiumID = new SelectList(db.Stadiums, "StadiumID", "Name", stadiumsteam.StadiumID);
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "Name", stadiumsteam.TeamID);
            return View(stadiumsteam);
        }

        //
        // POST: /Admin/AdminStadiumsInTeams/Edit/5

        [HttpPost]
        public ActionResult Edit(StadiumsTeam stadiumsteam)
        {
            if (ModelState.IsValid)
            {
                db.StadiumsTeams.Attach(stadiumsteam);
                db.ObjectStateManager.ChangeObjectState(stadiumsteam, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StadiumID = new SelectList(db.Stadiums, "StadiumID", "Name", stadiumsteam.StadiumID);
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "Name", stadiumsteam.TeamID);
            return View(stadiumsteam);
        }

        //
        // GET: /Admin/AdminStadiumsInTeams/Delete/5

        public ActionResult Delete(int id = 0)
        {
            StadiumsTeam stadiumsteam = db.StadiumsTeams.Single(s => s.StadiumID == id);
            if (stadiumsteam == null)
            {
                return HttpNotFound();
            }
            return View(stadiumsteam);
        }

        //
        // POST: /Admin/AdminStadiumsInTeams/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            StadiumsTeam stadiumsteam = db.StadiumsTeams.Single(s => s.StadiumID == id);
            db.StadiumsTeams.DeleteObject(stadiumsteam);
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