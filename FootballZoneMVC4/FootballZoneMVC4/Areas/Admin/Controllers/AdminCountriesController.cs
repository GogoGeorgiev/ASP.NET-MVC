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
    public class AdminCountriesController : BasicAdminController
    {
        private FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

        //
        // GET: /Admin/AdminCountries/

        public ViewResult Index(int start = 0, int itemsPerPage = 20, string orderBy = "CountryID", bool desc = false)
        {
            ViewBag.Count = db.Countries.Count();
            ViewBag.Start = start;
            ViewBag.ItemsPerPage = itemsPerPage;
            ViewBag.OrderBy = orderBy;
            ViewBag.Desc = desc;

            return View();
        }

        //
        // GET: /Admin/AdminCountries/GridData/?start=0&itemsPerPage=20&orderBy=CountryID&desc=true

        public ActionResult GridData(int start = 0, int itemsPerPage = 20, string orderBy = "CountryID", bool desc = false)
        {
            Response.AppendHeader("X-Total-Row-Count", db.Countries.Count().ToString());
            ObjectQuery<Country> countries = db.Countries;
            countries = countries.OrderBy("it." + orderBy + (desc ? " desc" : ""));

            return PartialView(countries.Skip(start).Take(itemsPerPage));
        }

        //
        // GET: /Default5/RowData/5

        public ActionResult RowData(int id)
        {
            Country country = db.Countries.Single(c => c.CountryID == id);
            return PartialView("GridData", new Country[] { country });
        }

        //
        // GET: /Admin/AdminCountries/Create

        public ActionResult Create()
        {
            return PartialView("Edit");
        }

        //
        // POST: /Admin/AdminCountries/Create

        [HttpPost]
        public ActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                db.Countries.AddObject(country);
                db.SaveChanges();
                return PartialView("GridData", new Country[] { country });
            }

            return PartialView("Edit", country);
        }

        //
        // GET: /Admin/AdminCountries/Edit/5

        public ActionResult Edit(int id)
        {
            Country country = db.Countries.Single(c => c.CountryID == id);
            return PartialView(country);
        }

        //
        // POST: /Admin/AdminCountries/Edit/5

        [HttpPost]
        public ActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                db.Countries.Attach(country);
                db.ObjectStateManager.ChangeObjectState(country, EntityState.Modified);
                db.SaveChanges();
                return PartialView("GridData", new Country[] { country });
            }

            return PartialView(country);
        }

        //
        // POST: /Admin/AdminCountries/Delete/5

        [HttpPost]
        public void Delete(int id)
        {
            Country country = db.Countries.Single(c => c.CountryID == id);
            db.Countries.DeleteObject(country);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
