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
    public class AdminSponsorsController : BasicAdminController
    {
        private FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

        //
        // GET: /Admin/AdminSponsors/

        public ViewResult Index(int start = 0, int itemsPerPage = 20, string orderBy = "SponsorID", bool desc = false)
        {
            ViewBag.Count = db.Sponsors.Count();
            ViewBag.Start = start;
            ViewBag.ItemsPerPage = itemsPerPage;
            ViewBag.OrderBy = orderBy;
            ViewBag.Desc = desc;

            return View();
        }

        //
        // GET: /Admin/AdminSponsors/GridData/?start=0&itemsPerPage=20&orderBy=SponsorID&desc=true

        public ActionResult GridData(int start = 0, int itemsPerPage = 20, string orderBy = "SponsorID", bool desc = false)
        {
            Response.AppendHeader("X-Total-Row-Count", db.Sponsors.Count().ToString());
            ObjectQuery<Sponsor> sponsors = db.Sponsors;
            sponsors = sponsors.OrderBy("it." + orderBy + (desc ? " desc" : ""));

            return PartialView(sponsors.Skip(start).Take(itemsPerPage));
        }

        //
        // GET: /Default5/RowData/5

        public ActionResult RowData(int id)
        {
            Sponsor sponsor = db.Sponsors.Single(s => s.SponsorID == id);
            return PartialView("GridData", new Sponsor[] { sponsor });
        }

        //
        // GET: /Admin/AdminSponsors/Create

        public ActionResult Create()
        {
            return PartialView("Edit");
        }

        //
        // POST: /Admin/AdminSponsors/Create

        [HttpPost]
        public ActionResult Create(Sponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                db.Sponsors.AddObject(sponsor);
                db.SaveChanges();
                return PartialView("GridData", new Sponsor[] { sponsor });
            }

            return PartialView("Edit", sponsor);
        }

        //
        // GET: /Admin/AdminSponsors/Edit/5

        public ActionResult Edit(int id)
        {
            Sponsor sponsor = db.Sponsors.Single(s => s.SponsorID == id);
            return PartialView(sponsor);
        }

        //
        // POST: /Admin/AdminSponsors/Edit/5

        [HttpPost]
        public ActionResult Edit(Sponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                db.Sponsors.Attach(sponsor);
                db.ObjectStateManager.ChangeObjectState(sponsor, EntityState.Modified);
                db.SaveChanges();
                return PartialView("GridData", new Sponsor[] { sponsor });
            }

            return PartialView(sponsor);
        }

        //
        // POST: /Admin/AdminSponsors/Delete/5

        [HttpPost]
        public void Delete(int id)
        {
            Sponsor sponsor = db.Sponsors.Single(s => s.SponsorID == id);
            db.Sponsors.DeleteObject(sponsor);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
