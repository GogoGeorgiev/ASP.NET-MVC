using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballZoneMVC4.DAL;
using FootballZoneMVC4.Models;


namespace FootballZoneMVC4.Controllers
{
    public class SponsorsInTeamsController : Controller
    {
        //
        // GET: /SponsorsInTeams/

        public ActionResult ViewSponsorsInTeams(int id)
        {
            List<SponsorsTeam> list = SponsorsInTeamsDAL.GetAllSponsorsInTeams(id);

            List<SponsorsInTeamsViewModel> viewModel = new List<SponsorsInTeamsViewModel>();

            foreach (var sponsor in list)
            {
                viewModel.Add(new SponsorsInTeamsViewModel(sponsor.Sponsor.Name, sponsor.Team.Name,
                    sponsor.Sponsor.ImageUrl, sponsor.Sponsor.Information, sponsor.FromDate.Date, sponsor.ToDate.Value));
                                                            
            }

            return View(viewModel);
        }

    }
}
