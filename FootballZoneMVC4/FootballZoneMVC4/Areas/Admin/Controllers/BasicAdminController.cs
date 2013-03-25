using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballZoneMVC4.Areas.Admin.Controllers
{
    [Authorize(Roles="Admin")]
    public class BasicAdminController : Controller
    {

    }
}