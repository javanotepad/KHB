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
    public class ManagementsTasksLookupsController : Controller
    {
        private KHBEntities db = new KHBEntities();

        // GET: Admin/ManagementsTasksLookups
        public ActionResult Index()
        {
            var managementsTasksLookups = db.ManagementsTasksLookups.Include(m => m.Management);
            return View(managementsTasksLookups.ToList());
        }

        // GET: Admin/ManagementsTasksLookups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManagementsTasksLookup managementsTasksLookup = db.ManagementsTasksLookups.Find(id);
            if (managementsTasksLookup == null)
            {
                return HttpNotFound();
            }
            return View(managementsTasksLookup);
        }

        // GET: Admin/ManagementsTasksLookups/Create
        public ActionResult Create()
        {
            ViewBag.MID = new SelectList(db.Managements, "MID", "MTitle");
            return View();
        }

        // POST: Admin/ManagementsTasksLookups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MTLID,MID,MTLText,CreationDate,IsDeleted")] ManagementsTasksLookup managementsTasksLookup)
        {
            if (ModelState.IsValid)
            {
                managementsTasksLookup.CreationDate = DateTime.Now;
                managementsTasksLookup.IsDeleted = false;
                db.ManagementsTasksLookups.Add(managementsTasksLookup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MID = new SelectList(db.Managements, "MID", "MTitle", managementsTasksLookup.MID);
            return View(managementsTasksLookup);
        }

        // GET: Admin/ManagementsTasksLookups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManagementsTasksLookup managementsTasksLookup = db.ManagementsTasksLookups.Find(id);
            if (managementsTasksLookup == null)
            {
                return HttpNotFound();
            }
            ViewBag.MID = new SelectList(db.Managements, "MID", "MTitle", managementsTasksLookup.MID);
            return View(managementsTasksLookup);
        }

        // POST: Admin/ManagementsTasksLookups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MTLID,MID,MTLText,CreationDate,IsDeleted")] ManagementsTasksLookup managementsTasksLookup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(managementsTasksLookup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MID = new SelectList(db.Managements, "MID", "MTitle", managementsTasksLookup.MID);
            return View(managementsTasksLookup);
        }

        // GET: Admin/ManagementsTasksLookups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManagementsTasksLookup managementsTasksLookup = db.ManagementsTasksLookups.Find(id);
            if (managementsTasksLookup == null)
            {
                return HttpNotFound();
            }
            return View(managementsTasksLookup);
        }

        // POST: Admin/ManagementsTasksLookups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManagementsTasksLookup managementsTasksLookup = db.ManagementsTasksLookups.Find(id);
            db.ManagementsTasksLookups.Remove(managementsTasksLookup);
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
