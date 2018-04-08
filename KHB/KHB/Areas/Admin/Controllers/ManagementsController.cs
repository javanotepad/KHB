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
    public class ManagementsController : Controller
    {
        private KHBEntities db = new KHBEntities();

        // GET: Admin/Managements
        public ActionResult Index()
        {
            return View(db.Managements.ToList());
        }

        // GET: Admin/Managements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Management management = db.Managements.Find(id);
            if (management == null)
            {
                return HttpNotFound();
            }
            return View(management);
        }

        // GET: Admin/Managements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Managements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MTitle")] Management management)
        {
            if (ModelState.IsValid)
            {
                management.CreationDate = DateTime.Now;
                management.IsDeleted = false;
                db.Managements.Add(management);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(management);
        }

        // GET: Admin/Managements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Management management = db.Managements.Find(id);
            if (management == null)
            {
                return HttpNotFound();
            }
            return View(management);
        }

        // POST: Admin/Managements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MID,MTitle,CreationDate,IsDeleted")] Management management)
        {
            if (ModelState.IsValid)
            {
                db.Entry(management).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(management);
        }

        // GET: Admin/Managements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Management management = db.Managements.Find(id);
            if (management == null)
            {
                return HttpNotFound();
            }
            return View(management);
        }

        // POST: Admin/Managements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Management management = db.Managements.Find(id);
            db.Managements.Remove(management);
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
