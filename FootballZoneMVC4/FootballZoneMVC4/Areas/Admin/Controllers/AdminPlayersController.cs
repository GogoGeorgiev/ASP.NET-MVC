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
    public class AdminPlayersController : BasicAdminController
    {
        private FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

        //
        // GET: /Admin/AdminPlayers/

        public ViewResult Index(int start = 0, int itemsPerPage = 20, string orderBy = "PlayerID", bool desc = false)
        {
            ViewBag.Count = db.Players.Count();
            ViewBag.Start = start;
            ViewBag.ItemsPerPage = itemsPerPage;
            ViewBag.OrderBy = orderBy;
            ViewBag.Desc = desc;

            return View();
        }

        //
        // GET: /Admin/AdminPlayers/GridData/?start=0&itemsPerPage=20&orderBy=PlayerID&desc=true

        public ActionResult GridData(int start = 0, int itemsPerPage = 20, string orderBy = "PlayerID", bool desc = false)
        {
            Response.AppendHeader("X-Total-Row-Count", db.Players.Count().ToString());
            ObjectQuery<Player> players = db.Players;
            players = players.OrderBy("it." + orderBy + (desc ? " desc" : ""));

            return PartialView(players.Skip(start).Take(itemsPerPage));
        }

        //
        // GET: /Default5/RowData/5

        public ActionResult RowData(int id)
        {
            Player player = db.Players.Single(p => p.PlayerID == id);
            return PartialView("GridData", new Player[] { player });
        }

        //
        // GET: /Admin/AdminPlayers/Create

        public ActionResult Create()
        {
            return PartialView("Edit");
        }

        //
        // POST: /Admin/AdminPlayers/Create

        [HttpPost]
        public ActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                db.Players.AddObject(player);
                db.SaveChanges();
                return PartialView("GridData", new Player[] { player });
            }

            return PartialView("Edit", player);
        }

        //
        // GET: /Admin/AdminPlayers/Edit/5

        public ActionResult Edit(int id)
        {
            Player player = db.Players.Single(p => p.PlayerID == id);
            return PartialView(player);
        }

        //
        // POST: /Admin/AdminPlayers/Edit/5

        [HttpPost]
        public ActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                db.Players.Attach(player);
                db.ObjectStateManager.ChangeObjectState(player, EntityState.Modified);
                db.SaveChanges();
                return PartialView("GridData", new Player[] { player });
            }

            return PartialView(player);
        }

        //
        // POST: /Admin/AdminPlayers/Delete/5

        [HttpPost]
        public void Delete(int id)
        {
            Player player = db.Players.Single(p => p.PlayerID == id);
            db.Players.DeleteObject(player);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
