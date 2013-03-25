using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballZoneMVC4.DAL;
using FootballZoneMVC4.Models;


namespace FootballZoneMVC4.Controllers
{
    public class StadiumsInTeamsController : Controller
    {
        //
        // GET: /StadiumsInTeams/

        public ActionResult ViewStadiumsInTeams(int id)
        {
            List<StadiumsTeam> list = StadiumsInTeamsDAL.GetAllStadiumsInTeams(id);

            List<StadiumsInTeamsViewModel> viewModel = new List<StadiumsInTeamsViewModel>();

            foreach (var stadium in list)
            {
                viewModel.Add(new StadiumsInTeamsViewModel(stadium.Stadium.Name, stadium.Team.Name,
                    stadium.Stadium.ImageUrl,stadium.Stadium.Information, stadium.FromDate, stadium.ToDate.Value));
                                                            
            }

            return View(viewModel);
        }

    }
}
