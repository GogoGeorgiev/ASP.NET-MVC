using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballZoneMVC4.DAL;
using FootballZoneMVC4.Models;

namespace FootballZoneMVC4.Controllers
{
    public class StadiumsController : Controller
    {
       
        public ActionResult viewStadiums()
        {
            List<Stadium> list = StadiumsDAL.GetAllStadiums();

            List<StadiumsViewModel> viewModel = new List<StadiumsViewModel>();

            foreach (var stadium in list)
            {
                viewModel.Add(new StadiumsViewModel(stadium.Name, stadium.Information, stadium.ImageUrl));
            }

            return View(viewModel);
        }

    }
}
