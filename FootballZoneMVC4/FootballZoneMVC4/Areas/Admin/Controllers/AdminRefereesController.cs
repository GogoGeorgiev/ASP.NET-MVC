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
    public class AdminRefereesController : BasicAdminController
    {
        private FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

        //
        // GET: /Admin/AdminReferees/

        public ViewResult Index(int start = 0, int itemsPerPage = 20, string orderBy = "RefereeID", bool desc = false)
        {
            ViewBag.Count = db.Referees.Count();
            ViewBag.Start = start;
            ViewBag.ItemsPerPage = itemsPerPage;
            ViewBag.OrderBy = orderBy;
            ViewBag.Desc = desc;

            return View();
        }

        //
        // GET: /Admin/AdminReferees/GridData/?start=0&itemsPerPage=20&orderBy=RefereeID&desc=true

        public ActionResult GridData(int start = 0, int itemsPerPage = 20, string orderBy = "RefereeID", bool desc = false)
        {
            Response.AppendHeader("X-Total-Row-Count", db.Referees.Count().ToString());
            ObjectQuery<Referee> referees = db.Referees;
            referees = referees.OrderBy("it." + orderBy + (desc ? " desc" : ""));

            return PartialView(referees.Skip(start).Take(itemsPerPage));
        }

        //
        // GET: /Default5/RowData/5

        public ActionResult RowData(int id)
        {
            Referee referee = db.Referees.Single(r => r.RefereeID == id);
            return PartialView("GridData", new Referee[] { referee });
        }

        //
        // GET: /Admin/AdminReferees/Create

        public ActionResult Create()
        {
            return PartialView("Edit");
        }

        //
        // POST: /Admin/AdminReferees/Create

        [HttpPost]
        public ActionResult Create(Referee referee)
        {
            if (ModelState.IsValid)
            {
                db.Referees.AddObject(referee);
                db.SaveChanges();
                return PartialView("GridData", new Referee[] { referee });
            }

            return PartialView("Edit", referee);
        }

        //
        // GET: /Admin/AdminReferees/Edit/5

        public ActionResult Edit(int id)
        {
            Referee referee = db.Referees.Single(r => r.RefereeID == id);
            return PartialView(referee);
        }

        //
        // POST: /Admin/AdminReferees/Edit/5

        [HttpPost]
        public ActionResult Edit(Referee referee)
        {
            if (ModelState.IsValid)
            {
                db.Referees.Attach(referee);
                db.ObjectStateManager.ChangeObjectState(referee, EntityState.Modified);
                db.SaveChanges();
                return PartialView("GridData", new Referee[] { referee });
            }

            return PartialView(referee);
        }

        //
        // POST: /Admin/AdminReferees/Delete/5

        [HttpPost]
        public void Delete(int id)
        {
            Referee referee = db.Referees.Single(r => r.RefereeID == id);
            db.Referees.DeleteObject(referee);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
