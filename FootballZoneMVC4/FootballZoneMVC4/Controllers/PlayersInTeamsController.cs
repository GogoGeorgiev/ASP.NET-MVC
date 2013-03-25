using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballZoneMVC4.Models;
using FootballZoneMVC4.DAL;


namespace FootballZoneMVC4.Controllers
{
    public class PlayersInTeamsController : Controller
    {

        private FootballZoneMVC4Entities db = new FootballZoneMVC4Entities();

        //
        // GET: /Admin/AdminPlayersInTeams/

        public ActionResult Index()
        {
            var playersteams = db.PlayersTeams.Include("Team").Include("Player");

            return View(playersteams.ToList());
        }

        //
        // GET: /Admin/AdminPlayersInTeams/Details/5

        public ActionResult PlayerDetails(int id)
        {
            PlayersTeam playersteam = db.PlayersTeams.Single(p => p.TeamID == id);
            if (playersteam == null)
            {
                return HttpNotFound();
            }
            return View(playersteam);
        }
        public ActionResult viewPlayersInTeams(int id)
        {

            List<PlayersTeam> list = PlayersTeamsDAL.GetAllPlayersInTeams(id);

            List<PlayersInTeamsViewModel> viewModel = new List<PlayersInTeamsViewModel>();

            foreach (var item in list)
            {
                viewModel.Add(new PlayersInTeamsViewModel(item.Player.PlayerNames,
                    item.Team.Name, item.Player.ImageUrl, item.Player.Biography, item.FromDate, item.ToDate.Value, item.PlayerKind));
            }

            return View(viewModel);
        }

    }
}
