using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballZoneMVC4.Models;
using FootballZoneMVC4.DAL;


namespace FootballZoneMVC4.Controllers
{
    public class RefereesInMatchesController : Controller
    {
        //
        // GET: /RefereesInMatches/

        public ActionResult ViewRefereesInMatches(int id)
        {
            List<RefereesMatch> list = RefereesInMatchesDAL.GetAllRefereesInMatches(id);

            List<RefereeInMatchesViewModel> viewModel = new List<RefereeInMatchesViewModel>();

            foreach (var item in list)
            {

                viewModel.Add(new RefereeInMatchesViewModel(item.Referee.RefereeNames, item.Referee.ImageUrl,
                            item.Referee.Biography, item.RefereeKind, item.FootballMatch.Information,
                            item.FootballMatch.Team.Name, item.FootballMatch.Team1.Name, item.FootballMatch.FinalScore,
                            item.FootballMatch.MatchDate, item.FootballMatch.Team.ImageUrl,
                            item.FootballMatch.Team1.ImageUrl, item.FootballMatch.Tournament.Name));                                
                                                                
            }

            return View(viewModel);
        }

    }
}
