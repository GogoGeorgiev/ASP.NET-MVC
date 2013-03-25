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
    public class AdminTeamsController : BasicAdminController
    {
        private FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

        //
        // GET: /Admin/AdminTeams/

        public ViewResult Index(int start = 0, int itemsPerPage = 20, string orderBy = "TeamID", bool desc = false)
        {
            ViewBag.Count = db.Teams.Count();
            ViewBag.Start = start;
            ViewBag.ItemsPerPage = itemsPerPage;
            ViewBag.OrderBy = orderBy;
            ViewBag.Desc = desc;

            return View();
        }

        //
        // GET: /Admin/AdminTeams/GridData/?start=0&itemsPerPage=20&orderBy=TeamID&desc=true

        public ActionResult GridData(int start = 0, int itemsPerPage = 20, string orderBy = "TeamID", bool desc = false)
        {
            Response.AppendHeader("X-Total-Row-Count", db.Teams.Count().ToString());
            ObjectQuery<Team> teams = db.Teams.Include("Country");
            teams = teams.OrderBy("it." + orderBy + (desc ? " desc" : ""));

            return PartialView(teams.Skip(start).Take(itemsPerPage));
        }

        //
        // GET: /Default5/RowData/5

        public ActionResult RowData(int id)
        {
            Team team = db.Teams.Single(t => t.TeamID == id);
            return PartialView("GridData", new Team[] { team });
        }

        //
        // GET: /Admin/AdminTeams/Create

        public ActionResult Create()
        {
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name");
            return PartialView("Edit");
        }

        //
        // POST: /Admin/AdminTeams/Create

        [HttpPost]
        public ActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                db.Teams.AddObject(team);
                db.SaveChanges();
                return PartialView("GridData", new Team[] { team });
            }

            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name", team.CountryID);
            return PartialView("Edit", team);
        }

        //
        // GET: /Admin/AdminTeams/Edit/5

        public ActionResult Edit(int id)
        {
            Team team = db.Teams.Single(t => t.TeamID == id);
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name", team.CountryID);
            return PartialView(team);
        }

        //
        // POST: /Admin/AdminTeams/Edit/5

        [HttpPost]
        public ActionResult Edit(Team team)
        {
            if (ModelState.IsValid)
            {
                db.Teams.Attach(team);
                db.ObjectStateManager.ChangeObjectState(team, EntityState.Modified);
                db.SaveChanges();
                return PartialView("GridData", new Team[] { team });
            }

            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name", team.CountryID);
            return PartialView(team);
        }

        //
        // POST: /Admin/AdminTeams/Delete/5

        [HttpPost]
        public void Delete(int id)
        {
            Team team = db.Teams.Single(t => t.TeamID == id);
            db.Teams.DeleteObject(team);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
