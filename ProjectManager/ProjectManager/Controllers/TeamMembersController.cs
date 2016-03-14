using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectManager.Models;
using Microsoft.AspNet.Identity;

namespace ProjectManager.Controllers
{
    public class TeamMembersController : Controller
    {
        private PMDBcontext db = new PMDBcontext();
        ProjectManager.Models.TeamMember tm = new Models.TeamMember();
        
        public ActionResult MyProject()
        {
            var id = User.Identity.GetUserId();
            var email = User.Identity.GetUserName();
            var model = db.TeamMembers.Where(x => x.Name == email).Select(x => x).FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public ActionResult MyProject([Bind(Include = "ID,TaskComplete")] TeamMember teamMember)
        {
            if (ModelState.IsValid)
            {
                var id = User.Identity.GetUserId();
                var email = User.Identity.GetUserName();
                var model = db.TeamMembers.Where(x => x.Name == email).Select(x => x).FirstOrDefault();

                model.TaskComplete = teamMember.TaskComplete;
                db.SaveChanges();

                if (model.TaskComplete == true)
                {
                    return RedirectToAction("Project", teamMember);
                }
                else
                {
                    return RedirectToAction("MyProject");
                }
                
                
               
               
            }
            return View();
        }
        // GET: TeamMembers
        public ActionResult Index()
        {
           
            return View(db.TeamMembers.ToList());
        }
        //public ActionResult MyProject()
        //{
        //    var model = new Models.TeamMember()
        //    {
        //        TaskStatus= getTaskStatus(),
        //    }
        //    return View("MyProject", );
        //}
        //public bool getTaskStatus()
        //{
        //    db.TeamMembers.Select()
        //}

        // GET: TeamMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMember teamMember = db.TeamMembers.Find(id);
            if (teamMember == null)
            {
                return HttpNotFound();
            }
            return View(teamMember);
        }

        // GET: TeamMembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeamMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Role,Name,Task")] TeamMember teamMember)
        {
            if (ModelState.IsValid)
            {
                db.TeamMembers.Add(teamMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teamMember);
        }

        // GET: TeamMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMember teamMember = db.TeamMembers.Find(id);
            if (teamMember == null)
            {
                return HttpNotFound();
            }
            return View(teamMember);
        }

        // POST: TeamMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Role,Name,Task")] TeamMember teamMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teamMember);
        }

        // GET: TeamMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMember teamMember = db.TeamMembers.Find(id);
            if (teamMember == null)
            {
                return HttpNotFound();
            }
            return View(teamMember);
        }
        public ActionResult Project(TeamMember tm)
        {
            return View(tm);
        }

        // POST: TeamMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamMember teamMember = db.TeamMembers.Find(id);
            db.TeamMembers.Remove(teamMember);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Assign()
        {
            return View("AssignTM");
        }
        [HttpPost]
        public ActionResult Assign([Bind(Include = "ID,Project,Name,Task")] TeamMember teamMember)
        {
            if (ModelState.IsValid)
            {
                var user = db.TeamMembers.Where(x => x.Name == teamMember.Name).Select(x => x).FirstOrDefault();
                var project = db.Projects.Where(x => x.ProjectName == teamMember.Project.ProjectName).Select(x => x).FirstOrDefault();
                var task = db.TeamMembers.Where(x => x.Task == teamMember.Task).Select(x => x).FirstOrDefault();
                user.Project = project;
                user.Task = teamMember.Task;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teamMember);
        }
    }
}
