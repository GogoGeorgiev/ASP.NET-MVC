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
    public class AdminPlayersInTeamsController : BasicAdminController
    {
        private FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

        //
        // GET: /Admin/AdminPlayersInTeams/

        public ActionResult Index()
        {
            var playersteams = db.PlayersTeams.Include("Team").Include("Player");
            return View(playersteams.ToList());
        }

        //
        // GET: /Admin/AdminPlayersInTeams/Details/5

        public ActionResult Details(int id = 0)
        {
            PlayersTeam playersteam = db.PlayersTeams.Single(p => p.PlayerID == id);
            if (playersteam == null)
            {
                return HttpNotFound();
            }
            return View(playersteam);
        }

        //
        // GET: /Admin/AdminPlayersInTeams/Create

        public ActionResult Create()
        {
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "Name");
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "PlayerNames");
            return View();
        }

        //
        // POST: /Admin/AdminPlayersInTeams/Create

        [HttpPost]
        public ActionResult Create(PlayersTeam playersteam)
        {
            if (ModelState.IsValid)
            {
                db.PlayersTeams.AddObject(playersteam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "Name", playersteam.TeamID);
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "PlayerNames", playersteam.PlayerID);
            return View(playersteam);
        }

        //
        // GET: /Admin/AdminPlayersInTeams/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PlayersTeam playersteam = db.PlayersTeams.Single(p => p.PlayerID == id);
            if (playersteam == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "Name", playersteam.TeamID);
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "PlayerNames", playersteam.PlayerID);
            return View(playersteam);
        }

        //
        // POST: /Admin/AdminPlayersInTeams/Edit/5

        [HttpPost]
        public ActionResult Edit(PlayersTeam playersteam)
        {
            if (ModelState.IsValid)
            {
                db.PlayersTeams.Attach(playersteam);
                db.ObjectStateManager.ChangeObjectState(playersteam, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "Name", playersteam.TeamID);
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "PlayerNames", playersteam.PlayerID);
            return View(playersteam);
        }

        //
        // GET: /Admin/AdminPlayersInTeams/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PlayersTeam playersteam = db.PlayersTeams.Single(p => p.PlayerID == id);
            if (playersteam == null)
            {
                return HttpNotFound();
            }
            return View(playersteam);
        }

        //
        // POST: /Admin/AdminPlayersInTeams/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayersTeam playersteam = db.PlayersTeams.Single(p => p.PlayerID == id);
            db.PlayersTeams.DeleteObject(playersteam);
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