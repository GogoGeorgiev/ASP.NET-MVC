using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballZoneMVC4.DAL;
using FootballZoneMVC4.Models;

namespace FootballZoneMVC4.Controllers
{
    public class FootballMatchesController : Controller
    {
        public ActionResult ViewFootballMatches()
        {
            List<FootballMatch> list = FootballMatchesDAL.GetAllMatches();

            List<FootballMatchesViewModel> viewModel = new List<FootballMatchesViewModel>();

            foreach (var match in list)
            {
                viewModel.Add(new FootballMatchesViewModel(match.MatchID,match.Tournament.Name, match.Team.Name, match.Team1.Name,
                                                                match.FinalScore, match.MatchDate, match.Information));
            }

            return View(viewModel);
        }

    }
}
