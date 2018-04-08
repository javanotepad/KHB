using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBL;

namespace KHB.Areas.Admin.Controllers
{
    public class TasksController : Controller
    {
        private KHBEntities db = new KHBEntities();

        // GET: Admin/Tasks
        public ActionResult Index()
        {
            var tasks = db.Tasks.Include(t => t.Management).Include(t => t.User).Include(t => t.YearWeek);
            var mtasks = db.ManagementsTasksLookups.Where(x=>x.)
            return View(tasks.ToList());
        }

        public PartialViewResult GetUserManagement(int managementId)
        {
            var management = db.Managements.SingleOrDefault(x => x.MID == managementId);
            return PartialView(management);
        }
        // GET: Admin/Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Admin/Tasks/Create
        public ActionResult Create()
        {
            ViewBag.MID = new SelectList(db.Managements, "MID", "MTitle");
            ViewBag.UID = new SelectList(db.Users, "UID", "UFullName");
            ViewBag.WID = new SelectList(db.YearWeeks, "WID", "WTitle");
            return View();
        }

        // POST: Admin/Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TID,MID,UID,MTLID,WID,NumberOfDone,CreationDate,IsDeleted")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MID = new SelectList(db.Managements, "MID", "MTitle", task.MID);
            ViewBag.UID = new SelectList(db.Users, "UID", "UFullName", task.UID);
            ViewBag.WID = new SelectList(db.YearWeeks, "WID", "WTitle", task.WID);
            return View(task);
        }

        // GET: Admin/Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.MID = new SelectList(db.Managements, "MID", "MTitle", task.MID);
            ViewBag.UID = new SelectList(db.Users, "UID", "UFullName", task.UID);
            ViewBag.WID = new SelectList(db.YearWeeks, "WID", "WTitle", task.WID);
            return View(task);
        }

        // POST: Admin/Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TID,MID,UID,MTLID,WID,NumberOfDone,CreationDate,IsDeleted")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MID = new SelectList(db.Managements, "MID", "MTitle", task.MID);
            ViewBag.UID = new SelectList(db.Users, "UID", "UFullName", task.UID);
            ViewBag.WID = new SelectList(db.YearWeeks, "WID", "WTitle", task.WID);
            return View(task);
        }

        // GET: Admin/Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Admin/Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
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
