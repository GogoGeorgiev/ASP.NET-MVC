using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballZoneMVC4.Models;
using FootballZoneMVC4.DAL;

namespace FootballZoneMVC4.Controllers
{
    public class RefereesController : Controller
    {
        

        public ActionResult viewReferees()
        {
            List<Referee> list = RefereesDAL.GetAllReferees();
            List<RefereesViewModel> viewModel = new List<RefereesViewModel>();

            foreach (var referee in list)
            {
                viewModel.Add(new RefereesViewModel(referee.RefereeNames, referee.Biography, referee.ImageUrl));
            }

            return View(viewModel);
        
        }

    }
}
