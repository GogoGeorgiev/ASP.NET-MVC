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
    public class AdminAssociationsController : BasicAdminController
    {
        private FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

        //
        // GET: /Admin/AdminAssociations/

        public ViewResult Index(int start = 0, int itemsPerPage = 20, string orderBy = "AssociationID", bool desc = false)
        {
            ViewBag.Count = db.FootballAssociations.Count();
            ViewBag.Start = start;
            ViewBag.ItemsPerPage = itemsPerPage;
            ViewBag.OrderBy = orderBy;
            ViewBag.Desc = desc;

            return View();
        }

        //
        // GET: /Admin/AdminAssociations/GridData/?start=0&itemsPerPage=20&orderBy=AssociationID&desc=true

        public ActionResult GridData(int start = 0, int itemsPerPage = 20, string orderBy = "AssociationID", bool desc = false)
        {
            Response.AppendHeader("X-Total-Row-Count", db.FootballAssociations.Count().ToString());
            ObjectQuery<FootballAssociation> footballassociations = db.FootballAssociations;
            footballassociations = footballassociations.OrderBy("it." + orderBy + (desc ? " desc" : ""));

            return PartialView(footballassociations.Skip(start).Take(itemsPerPage));
        }

        //
        // GET: /Default5/RowData/5

        public ActionResult RowData(int id)
        {
            FootballAssociation footballassociation = db.FootballAssociations.Single(f => f.AssociationID == id);
            return PartialView("GridData", new FootballAssociation[] { footballassociation });
        }

        //
        // GET: /Admin/AdminAssociations/Create

        public ActionResult Create()
        {
            return PartialView("Edit");
        }

        //
        // POST: /Admin/AdminAssociations/Create

        [HttpPost]
        public ActionResult Create(FootballAssociation footballassociation)
        {
            if (ModelState.IsValid)
            {
                db.FootballAssociations.AddObject(footballassociation);
                db.SaveChanges();
                return PartialView("GridData", new FootballAssociation[] { footballassociation });
            }

            return PartialView("Edit", footballassociation);
        }

        //
        // GET: /Admin/AdminAssociations/Edit/5

        public ActionResult Edit(int id)
        {
            FootballAssociation footballassociation = db.FootballAssociations.Single(f => f.AssociationID == id);
            return PartialView(footballassociation);
        }

        //
        // POST: /Admin/AdminAssociations/Edit/5

        [HttpPost]
        public ActionResult Edit(FootballAssociation footballassociation)
        {
            if (ModelState.IsValid)
            {
                db.FootballAssociations.Attach(footballassociation);
                db.ObjectStateManager.ChangeObjectState(footballassociation, EntityState.Modified);
                db.SaveChanges();
                return PartialView("GridData", new FootballAssociation[] { footballassociation });
            }

            return PartialView(footballassociation);
        }

        //
        // POST: /Admin/AdminAssociations/Delete/5

        [HttpPost]
        public void Delete(int id)
        {
            FootballAssociation footballassociation = db.FootballAssociations.Single(f => f.AssociationID == id);
            db.FootballAssociations.DeleteObject(footballassociation);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
