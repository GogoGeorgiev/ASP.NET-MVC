using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballZoneMVC4.Models;
using FootballZoneMVC4.DAL;

namespace FootballZoneMVC4.Controllers
{
    public class CoachesController : Controller
    {
        //
        // GET: /Coaches/

        public ActionResult ViewCoaches()
        {
            List<Coach> list = CoachesDAL.GetAllCoaches();

            List<CoachesViewModel> viewModel = new List<CoachesViewModel>();

            foreach (var coach in list)
            {
                viewModel.Add(new CoachesViewModel(coach.CoachNames, coach.Biography, coach.ImageUrl));
            }

            return View(viewModel);
        }

    }
}

