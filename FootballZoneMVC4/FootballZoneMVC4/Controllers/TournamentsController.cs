using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballZoneMVC4.DAL;
using FootballZoneMVC4.Models;

namespace FootballZoneMVC4.Controllers
{
    public class TournamentsController : Controller
    {
      

        public ActionResult viewTournaments()
        {
            List<Tournament> list = TournamentsDAL.GetAllTournaments();

            List<TournamentsViewModel> viewModel = new List<TournamentsViewModel>();

            foreach (var item in list)
            {
                viewModel.Add(new TournamentsViewModel(item.Name, item.Information, item.ImageUrl,
                                                            item.FootballAssociation.Name));
            }

            return View(viewModel);
        }

    }
}
