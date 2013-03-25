using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballZoneMVC4.DAL;
using FootballZoneMVC4.Models;

namespace FootballZoneMVC4.Controllers
{
    public class CoachesInTeamsController : Controller
    {
        //
        // GET: /CoachesInTeams/

        public ActionResult ViewCoachesInTeams(int id)
        {

            List<CoachesTeam> list = CoachesInTeamsDAL.GetAllCoachesInTeams(id);

            List<CoachesInTeamsViewModel> viewModel = new List<CoachesInTeamsViewModel>();

            foreach (var item in list)
            {
                viewModel.Add(new CoachesInTeamsViewModel(
                     item.Coach.CoachNames, item.Team.Name,item.Coach.ImageUrl, item.Coach.Biography,
                     item.FromDate.Date, item.ToDate.Value, item.CoachKind));
                                                                                               
            }

            return View(viewModel);

        }

    }
}
