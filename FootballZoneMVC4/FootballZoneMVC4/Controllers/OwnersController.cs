using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballZoneMVC4.DAL;
using FootballZoneMVC4.Models;

namespace FootballZoneMVC4.Controllers
{
    public class OwnersController : Controller
    {
        

        public ActionResult ViewOwners()
        {
            List<Owner> list = OwnersDAL.GetAllOwners();

            List<OwnersViewModel> viewModel = new List<OwnersViewModel>();

            foreach (var owner in list)
            {
                viewModel.Add(new OwnersViewModel(owner.OwnerNames, owner.Biography, owner.ImageUrl));
            }

            return View(viewModel);
            
        }

    }
}
