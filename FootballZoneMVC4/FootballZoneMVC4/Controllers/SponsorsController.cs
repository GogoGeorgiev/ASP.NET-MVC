using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballZoneMVC4.DAL;
using FootballZoneMVC4.Models;

namespace FootballZoneMVC4.Controllers
{
    public class SponsorsController : Controller
    {

        public ActionResult ViewSponsors()
        {
            List<Sponsor> list = SponsorsDAL.GetAllSponsors();

            List<SponsorsViewModel> viewModel = new List<SponsorsViewModel>();

            foreach (var sponsor in list)
            {
                viewModel.Add(new SponsorsViewModel(sponsor.Name, sponsor.Information, sponsor.ImageUrl));
            }

            return View(viewModel);
        }

    }


}
