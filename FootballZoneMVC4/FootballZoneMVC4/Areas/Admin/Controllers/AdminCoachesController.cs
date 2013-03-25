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
    public class AdminCoachesController : BasicAdminController
    {
        private FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

        //
        // GET: /Admin/AdminCoaches/

        public ViewResult Index(int start = 0, int itemsPerPage = 20, string orderBy = "CoachID", bool desc = false)
        {
            ViewBag.Count = db.Coaches.Count();
            ViewBag.Start = start;
            ViewBag.ItemsPerPage = itemsPerPage;
            ViewBag.OrderBy = orderBy;
            ViewBag.Desc = desc;

            return View();
        }

        //
        // GET: /Admin/AdminCoaches/GridData/?start=0&itemsPerPage=20&orderBy=CoachID&desc=true

        public ActionResult GridData(int start = 0, int itemsPerPage = 20, string orderBy = "CoachID", bool desc = false)
        {
            Response.AppendHeader("X-Total-Row-Count", db.Coaches.Count().ToString());
            ObjectQuery<Coach> coaches = db.Coaches;
            coaches = coaches.OrderBy("it." + orderBy + (desc ? " desc" : ""));

            return PartialView(coaches.Skip(start).Take(itemsPerPage));
        }

        //
        // GET: /Default5/RowData/5

        public ActionResult RowData(int id)
        {
            Coach coach = db.Coaches.Single(c => c.CoachID == id);
            return PartialView("GridData", new Coach[] { coach });
        }

        //
        // GET: /Admin/AdminCoaches/Create

        public ActionResult Create()
        {
            return PartialView("Edit");
        }

        //
        // POST: /Admin/AdminCoaches/Create

        [HttpPost]
        public ActionResult Create(Coach coach)
        {
            if (ModelState.IsValid)
            {
                db.Coaches.AddObject(coach);
                db.SaveChanges();
                return PartialView("GridData", new Coach[] { coach });
            }

            return PartialView("Edit", coach);
        }

        //
        // GET: /Admin/AdminCoaches/Edit/5

        public ActionResult Edit(int id)
        {
            Coach coach = db.Coaches.Single(c => c.CoachID == id);
            return PartialView(coach);
        }

        //
        // POST: /Admin/AdminCoaches/Edit/5

        [HttpPost]
        public ActionResult Edit(Coach coach)
        {
            if (ModelState.IsValid)
            {
                db.Coaches.Attach(coach);
                db.ObjectStateManager.ChangeObjectState(coach, EntityState.Modified);
                db.SaveChanges();
                return PartialView("GridData", new Coach[] { coach });
            }

            return PartialView(coach);
        }

        //
        // POST: /Admin/AdminCoaches/Delete/5

        [HttpPost]
        public void Delete(int id)
        {
            Coach coach = db.Coaches.Single(c => c.CoachID == id);
            db.Coaches.DeleteObject(coach);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
