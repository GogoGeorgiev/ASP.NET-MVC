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
    public class AdminOwnersController : BasicAdminController
    {
        private FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

        //
        // GET: /Admin/AdminOwners/

        public ViewResult Index(int start = 0, int itemsPerPage = 20, string orderBy = "OwnerID", bool desc = false)
        {
            ViewBag.Count = db.Owners.Count();
            ViewBag.Start = start;
            ViewBag.ItemsPerPage = itemsPerPage;
            ViewBag.OrderBy = orderBy;
            ViewBag.Desc = desc;

            return View();
        }

        //
        // GET: /Admin/AdminOwners/GridData/?start=0&itemsPerPage=20&orderBy=OwnerID&desc=true

        public ActionResult GridData(int start = 0, int itemsPerPage = 20, string orderBy = "OwnerID", bool desc = false)
        {
            Response.AppendHeader("X-Total-Row-Count", db.Owners.Count().ToString());
            ObjectQuery<Owner> owners = db.Owners;
            owners = owners.OrderBy("it." + orderBy + (desc ? " desc" : ""));

            return PartialView(owners.Skip(start).Take(itemsPerPage));
        }

        //
        // GET: /Default5/RowData/5

        public ActionResult RowData(int id)
        {
            Owner owner = db.Owners.Single(o => o.OwnerID == id);
            return PartialView("GridData", new Owner[] { owner });
        }

        //
        // GET: /Admin/AdminOwners/Create

        public ActionResult Create()
        {
            return PartialView("Edit");
        }

        //
        // POST: /Admin/AdminOwners/Create

        [HttpPost]
        public ActionResult Create(Owner owner)
        {
            if (ModelState.IsValid)
            {
                db.Owners.AddObject(owner);
                db.SaveChanges();
                return PartialView("GridData", new Owner[] { owner });
            }

            return PartialView("Edit", owner);
        }

        //
        // GET: /Admin/AdminOwners/Edit/5

        public ActionResult Edit(int id)
        {
            Owner owner = db.Owners.Single(o => o.OwnerID == id);
            return PartialView(owner);
        }

        //
        // POST: /Admin/AdminOwners/Edit/5

        [HttpPost]
        public ActionResult Edit(Owner owner)
        {
            if (ModelState.IsValid)
            {
                db.Owners.Attach(owner);
                db.ObjectStateManager.ChangeObjectState(owner, EntityState.Modified);
                db.SaveChanges();
                return PartialView("GridData", new Owner[] { owner });
            }

            return PartialView(owner);
        }

        //
        // POST: /Admin/AdminOwners/Delete/5

        [HttpPost]
        public void Delete(int id)
        {
            Owner owner = db.Owners.Single(o => o.OwnerID == id);
            db.Owners.DeleteObject(owner);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
