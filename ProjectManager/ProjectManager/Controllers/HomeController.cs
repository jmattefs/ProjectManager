using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Project()
        {
            ProjectManager.Models.ApplicationDbContext adbc = new ProjectManager.Models.ApplicationDbContext();
            int UserRole = adbc.Users.Select(x => x.Role).FirstOrDefault();
            if(UserRole == 1)
            {
                return RedirectToAction("Index", "TeamMembers");
            }
            else if (UserRole == 2)
            {
                return RedirectToAction("Index", "ScrumMasters");
            }
            else if (UserRole == 3)
            {
                return RedirectToAction("Index", "Clients");
            }
            else
            {
                return View("SorryNoProject");
            }
        }
    }
}