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
    public class AdminTournamentsController : BasicAdminController
    {
        private FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

        //
        // GET: /Admin/AdminTournaments/

        public ViewResult Index(int start = 0, int itemsPerPage = 20, string orderBy = "TournamentID", bool desc = false)
        {
            ViewBag.Count = db.Tournaments.Count();
            ViewBag.Start = start;
            ViewBag.ItemsPerPage = itemsPerPage;
            ViewBag.OrderBy = orderBy;
            ViewBag.Desc = desc;

            return View();
        }

        //
        // GET: /Admin/AdminTournaments/GridData/?start=0&itemsPerPage=20&orderBy=TournamentID&desc=true

        public ActionResult GridData(int start = 0, int itemsPerPage = 20, string orderBy = "TournamentID", bool desc = false)
        {
            Response.AppendHeader("X-Total-Row-Count", db.Tournaments.Count().ToString());
            ObjectQuery<Tournament> tournaments = db.Tournaments.Include("FootballAssociation");
            tournaments = tournaments.OrderBy("it." + orderBy + (desc ? " desc" : ""));

            return PartialView(tournaments.Skip(start).Take(itemsPerPage));
        }

        //
        // GET: /Default5/RowData/5

        public ActionResult RowData(int id)
        {
            Tournament tournament = db.Tournaments.Single(t => t.TournamentID == id);
            return PartialView("GridData", new Tournament[] { tournament });
        }

        //
        // GET: /Admin/AdminTournaments/Create

        public ActionResult Create()
        {
            ViewBag.AssociationID = new SelectList(db.FootballAssociations, "AssociationID", "Name");
            return PartialView("Edit");
        }

        //
        // POST: /Admin/AdminTournaments/Create

        [HttpPost]
        public ActionResult Create(Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                db.Tournaments.AddObject(tournament);
                db.SaveChanges();
                return PartialView("GridData", new Tournament[] { tournament });
            }

            ViewBag.AssociationID = new SelectList(db.FootballAssociations, "AssociationID", "Name", tournament.AssociationID);
            return PartialView("Edit", tournament);
        }

        //
        // GET: /Admin/AdminTournaments/Edit/5

        public ActionResult Edit(int id)
        {
            Tournament tournament = db.Tournaments.Single(t => t.TournamentID == id);
            ViewBag.AssociationID = new SelectList(db.FootballAssociations, "AssociationID", "Name", tournament.AssociationID);
            return PartialView(tournament);
        }

        //
        // POST: /Admin/AdminTournaments/Edit/5

        [HttpPost]
        public ActionResult Edit(Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                db.Tournaments.Attach(tournament);
                db.ObjectStateManager.ChangeObjectState(tournament, EntityState.Modified);
                db.SaveChanges();
                return PartialView("GridData", new Tournament[] { tournament });
            }

            ViewBag.AssociationID = new SelectList(db.FootballAssociations, "AssociationID", "Name", tournament.AssociationID);
            return PartialView(tournament);
        }

        //
        // POST: /Admin/AdminTournaments/Delete/5

        [HttpPost]
        public void Delete(int id)
        {
            Tournament tournament = db.Tournaments.Single(t => t.TournamentID == id);
            db.Tournaments.DeleteObject(tournament);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
