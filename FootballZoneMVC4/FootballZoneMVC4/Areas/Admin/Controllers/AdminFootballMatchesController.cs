using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballZoneMVC4.DAL;

namespace FootballZoneMVC4.Areas.Admin.Controllers
{
    public class AdminFootballMatchesController : BasicAdminController
    {
        private FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

        //
        // GET: /Admin/AdminFootballMatches/

        public ViewResult Index(int start = 0, int itemsPerPage = 20, string orderBy = "MatchID", bool desc = false)
        {
            ViewBag.Count = db.FootballMatches.Count();
            ViewBag.Start = start;
            ViewBag.ItemsPerPage = itemsPerPage;
            ViewBag.OrderBy = orderBy;
            ViewBag.Desc = desc;

            return View();
        }

        //
        // GET: /Admin/AdminFootballMatches/GridData/?start=0&itemsPerPage=20&orderBy=MatchID&desc=true

        public ActionResult GridData(int start = 0, int itemsPerPage = 20, string orderBy = "MatchID", bool desc = false)
        {
            Response.AppendHeader("X-Total-Row-Count", db.FootballMatches.Count().ToString());
            ObjectQuery<FootballMatch> footballmatches = db.FootballMatches.Include("Team").Include("Team1").Include("Tournament");
            footballmatches = footballmatches.OrderBy("it." + orderBy + (desc ? " desc" : ""));

            return PartialView(footballmatches.Skip(start).Take(itemsPerPage));
        }

        //
        // GET: /Default5/RowData/5

        public ActionResult RowData(int id)
        {
            FootballMatch footballmatch = db.FootballMatches.Single(f => f.MatchID == id);
            return PartialView("GridData", new FootballMatch[] { footballmatch });
        }

        //
        // GET: /Admin/AdminFootballMatches/Create

        public ActionResult Create()
        {
            ViewBag.TeamA = new SelectList(db.Teams, "TeamID", "Name");
            ViewBag.TeamB = new SelectList(db.Teams, "TeamID", "Name");
            ViewBag.TournamentID = new SelectList(db.Tournaments, "TournamentID", "Name");
            return PartialView("Edit");
        }

        //
        // POST: /Admin/AdminFootballMatches/Create

        [HttpPost]
        public ActionResult Create(FootballMatch footballmatch)
        {
            if (ModelState.IsValid)
            {
                db.FootballMatches.AddObject(footballmatch);
                db.SaveChanges();
                return PartialView("GridData", new FootballMatch[] { footballmatch });
            }

            ViewBag.TeamA = new SelectList(db.Teams, "TeamID", "Name", footballmatch.TeamA);
            ViewBag.TeamB = new SelectList(db.Teams, "TeamID", "Name", footballmatch.TeamB);
            ViewBag.TournamentID = new SelectList(db.Tournaments, "TournamentID", "Name", footballmatch.TournamentID);
            return PartialView("Edit", footballmatch);
        }

        //
        // GET: /Admin/AdminFootballMatches/Edit/5

        public ActionResult Edit(int id)
        {
            FootballMatch footballmatch = db.FootballMatches.Single(f => f.MatchID == id);
            ViewBag.TeamA = new SelectList(db.Teams, "TeamID", "Name", footballmatch.TeamA);
            ViewBag.TeamB = new SelectList(db.Teams, "TeamID", "Name", footballmatch.TeamB);
            ViewBag.TournamentID = new SelectList(db.Tournaments, "TournamentID", "Name", footballmatch.TournamentID);
            return PartialView(footballmatch);
        }

        //
        // POST: /Admin/AdminFootballMatches/Edit/5

        [HttpPost]
        public ActionResult Edit(FootballMatch footballmatch)
        {
            if (ModelState.IsValid)
            {
                db.FootballMatches.Attach(footballmatch);
                db.ObjectStateManager.ChangeObjectState(footballmatch, EntityState.Modified);
                db.SaveChanges();
                return PartialView("GridData", new FootballMatch[] { footballmatch });
            }

            ViewBag.TeamA = new SelectList(db.Teams, "TeamID", "Name", footballmatch.TeamA);
            ViewBag.TeamB = new SelectList(db.Teams, "TeamID", "Name", footballmatch.TeamB);
            ViewBag.TournamentID = new SelectList(db.Tournaments, "TournamentID", "Name", footballmatch.TournamentID);
            return PartialView(footballmatch);
        }

        //
        // POST: /Admin/AdminFootballMatches/Delete/5

        [HttpPost]
        public void Delete(int id)
        {
            FootballMatch footballmatch = db.FootballMatches.Single(f => f.MatchID == id);
            db.FootballMatches.DeleteObject(footballmatch);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
