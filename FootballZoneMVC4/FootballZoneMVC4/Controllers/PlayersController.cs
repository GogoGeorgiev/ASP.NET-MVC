using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballZoneMVC4.DAL;
using FootballZoneMVC4.Models;


namespace FootballZoneMVC4.Controllers
{
    public class PlayersController : Controller
    {

        public ActionResult ViewPlayers()
        {
            List<Player> list = PlayersDAL.GetAllPlayers();

            List<PlayersViewModel> viewModel = new List<PlayersViewModel>();

            foreach (var player in list)
            {
                viewModel.Add(new PlayersViewModel(player.PlayerNames, player.Biography, player.ImageUrl));
            }

            return View(viewModel);
        }

    }
}
