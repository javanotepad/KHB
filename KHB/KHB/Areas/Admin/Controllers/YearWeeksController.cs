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
    public class YearWeeksController : Controller
    {
        private KHBEntities db = new KHBEntities();

        // GET: Admin/YearWeeks
        public ActionResult Index()
        {
            return View(db.YearWeeks.ToList());
        }

        // GET: Admin/YearWeeks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearWeek yearWeek = db.YearWeeks.Find(id);
            if (yearWeek == null)
            {
                return HttpNotFound();
            }
            return View(yearWeek);
        }

        // GET: Admin/YearWeeks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/YearWeeks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WID,WTitle,CreationDate,IsDeleted")] YearWeek yearWeek)
        {
            if (ModelState.IsValid)
            {
                yearWeek.CreationDate = DateTime.Now;
                yearWeek.IsDeleted = false;
                db.YearWeeks.Add(yearWeek);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yearWeek);
        }

        // GET: Admin/YearWeeks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearWeek yearWeek = db.YearWeeks.Find(id);
            if (yearWeek == null)
            {
                return HttpNotFound();
            }
            return View(yearWeek);
        }

        // POST: Admin/YearWeeks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WID,WTitle,CreationDate,IsDeleted")] YearWeek yearWeek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yearWeek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yearWeek);
        }

        // GET: Admin/YearWeeks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearWeek yearWeek = db.YearWeeks.Find(id);
            if (yearWeek == null)
            {
                return HttpNotFound();
            }
            return View(yearWeek);
        }

        // POST: Admin/YearWeeks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YearWeek yearWeek = db.YearWeeks.Find(id);
            db.YearWeeks.Remove(yearWeek);
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
