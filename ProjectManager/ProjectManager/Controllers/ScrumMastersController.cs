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
    public class ScrumMastersController : Controller
    {
        private PMDBcontext db = new PMDBcontext();

        // GET: ScrumMasters
        public ActionResult Index()
        {
            return View(db.ScrumMasters.ToList());
        }
        public ActionResult MyProject()
        {
            var id = User.Identity.GetUserId();
            var email = User.Identity.GetUserName();
            var model = db.TeamMembers.Where(x => x.Name == email).Select(x => x).FirstOrDefault();
            return View(model);
        }

        // GET: ScrumMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScrumMaster scrumMaster = db.ScrumMasters.Find(id);
            if (scrumMaster == null)
            {
                return HttpNotFound();
            }
            return View(scrumMaster);
        }

        // GET: ScrumMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScrumMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Role,Name")] ScrumMaster scrumMaster)
        {
            if (ModelState.IsValid)
            {
                db.ScrumMasters.Add(scrumMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scrumMaster);
        }

        // GET: ScrumMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScrumMaster scrumMaster = db.ScrumMasters.Find(id);
            if (scrumMaster == null)
            {
                return HttpNotFound();
            }
            return View(scrumMaster);
        }

        // POST: ScrumMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Role,Name")] ScrumMaster scrumMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scrumMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scrumMaster);
        }

        // GET: ScrumMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScrumMaster scrumMaster = db.ScrumMasters.Find(id);
            if (scrumMaster == null)
            {
                return HttpNotFound();
            }
            return View(scrumMaster);
        }

        // POST: ScrumMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScrumMaster scrumMaster = db.ScrumMasters.Find(id);
            db.ScrumMasters.Remove(scrumMaster);
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
    }
}
