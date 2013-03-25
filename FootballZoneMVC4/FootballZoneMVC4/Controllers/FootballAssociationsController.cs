using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballZoneMVC4.Models;
using FootballZoneMVC4.DAL;

namespace FootballZoneMVC4.Controllers
{
    public class FootballAssociationsController : Controller
    {
        

        public ActionResult ViewAssociations()
        {
            List<FootballAssociation> list = FootballAssociationsDAL.GetAllAssociations();

            List<FootballAssociationsViewModel> viewModel = new List<FootballAssociationsViewModel>();

            foreach (var association in list)
            {
                viewModel.Add(new FootballAssociationsViewModel(association.Name, association.Information, 
                                                                  association.ImageUrl));
            }

            return View(viewModel);
        }

    }
}
