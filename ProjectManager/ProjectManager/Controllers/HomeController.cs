using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

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
            ProjectManager.Models.TeamMember tm = new Models.TeamMember();
            ProjectManager.Models.ScrumMaster sm = new Models.ScrumMaster();
            ProjectManager.Models.Client c = new Models.Client();
            string UserID = User.Identity.GetUserId();
            int UserRole = adbc.Users.Where(x => x.Id == UserID).Select(x => x.Role).FirstOrDefault();
            if(UserRole == 1)
            {
               
                return RedirectToAction("MyProject", "TeamMembers");
            }
            else if (UserRole == 2)
            {
                return RedirectToAction("Create", "Projects");
            }
            else if (UserRole == 3)
            {
                return RedirectToAction("Details", "Clients");
            }
            else
            {
                return View("SorryNoProject");
            }
        }
    }
}