using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballZoneMVC4.DAL;
using FootballZoneMVC4.Models;

namespace FootballZoneMVC4.Controllers
{
    public class OwnersInTeamsController : Controller
    {
        //
        // GET: /OwnersInTeams/

        public ActionResult ViewOwnersInTeams(int id)
        {
            List<OwnersTeam> list = OwnersInTeamsDAL.GetAllOwnersInTeams(id);

            List<OwnersInTeamsViewModel> viewModel = new List<OwnersInTeamsViewModel>();

            foreach (var owner in list)
            {
                viewModel.Add(new OwnersInTeamsViewModel(owner.Owner.OwnerNames, owner.Team.Name,
                    owner.Owner.ImageUrl, owner.Owner.Biography, owner.FromDate.Date, owner.ToDate.Value));

                                                           
            }

            return View(viewModel);
        }

    }
}
