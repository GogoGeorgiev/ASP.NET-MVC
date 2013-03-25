using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballZoneMVC4.Models;
using FootballZoneMVC4.DAL;
using FootballZoneMVC4.ViewModels;


namespace FootballZoneMVC4.Controllers
{
    public class TeamsController : Controller
    {


        public ActionResult TeamDetails(int id)
        {
            FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();
            Team team = db.Teams.SingleOrDefault(t => t.TeamID == id);
            return View(team);
        }

        public ActionResult ViewTeams()
        {
            var getTeams = TeamsDAL.GetAllTeams();
            var teams = new List<TeamsViewModel>();
            foreach (var item in getTeams)
            {
                teams.Add(new TeamsViewModel(item.TeamID, item.Name, item.Biography, item.Country.Name, item.ImageUrl));
            }

            return View(teams);

        }

    }
}
