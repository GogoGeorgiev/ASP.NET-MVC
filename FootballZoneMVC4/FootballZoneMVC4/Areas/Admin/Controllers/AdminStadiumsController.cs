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
    public class AdminStadiumsController : BasicAdminController
    {
        private FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

        //
        // GET: /Admin/AdminStadiums/

        public ViewResult Index(int start = 0, int itemsPerPage = 20, string orderBy = "StadiumID", bool desc = false)
        {
            ViewBag.Count = db.Stadiums.Count();
            ViewBag.Start = start;
            ViewBag.ItemsPerPage = itemsPerPage;
            ViewBag.OrderBy = orderBy;
            ViewBag.Desc = desc;

            return View();
        }

        //
        // GET: /Admin/AdminStadiums/GridData/?start=0&itemsPerPage=20&orderBy=StadiumID&desc=true

        public ActionResult GridData(int start = 0, int itemsPerPage = 20, string orderBy = "StadiumID", bool desc = false)
        {
            Response.AppendHeader("X-Total-Row-Count", db.Stadiums.Count().ToString());
            ObjectQuery<Stadium> stadiums = db.Stadiums;
            stadiums = stadiums.OrderBy("it." + orderBy + (desc ? " desc" : ""));

            return PartialView(stadiums.Skip(start).Take(itemsPerPage));
        }

        //
        // GET: /Default5/RowData/5

        public ActionResult RowData(int id)
        {
            Stadium stadium = db.Stadiums.Single(s => s.StadiumID == id);
            return PartialView("GridData", new Stadium[] { stadium });
        }

        //
        // GET: /Admin/AdminStadiums/Create

        public ActionResult Create()
        {
            return PartialView("Edit");
        }

        //
        // POST: /Admin/AdminStadiums/Create

        [HttpPost]
        public ActionResult Create(Stadium stadium)
        {
            if (ModelState.IsValid)
            {
                db.Stadiums.AddObject(stadium);
                db.SaveChanges();
                return PartialView("GridData", new Stadium[] { stadium });
            }

            return PartialView("Edit", stadium);
        }

        //
        // GET: /Admin/AdminStadiums/Edit/5

        public ActionResult Edit(int id)
        {
            Stadium stadium = db.Stadiums.Single(s => s.StadiumID == id);
            return PartialView(stadium);
        }

        //
        // POST: /Admin/AdminStadiums/Edit/5

        [HttpPost]
        public ActionResult Edit(Stadium stadium)
        {
            if (ModelState.IsValid)
            {
                db.Stadiums.Attach(stadium);
                db.ObjectStateManager.ChangeObjectState(stadium, EntityState.Modified);
                db.SaveChanges();
                return PartialView("GridData", new Stadium[] { stadium });
            }

            return PartialView(stadium);
        }

        //
        // POST: /Admin/AdminStadiums/Delete/5

        [HttpPost]
        public void Delete(int id)
        {
            Stadium stadium = db.Stadiums.Single(s => s.StadiumID == id);
            db.Stadiums.DeleteObject(stadium);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
