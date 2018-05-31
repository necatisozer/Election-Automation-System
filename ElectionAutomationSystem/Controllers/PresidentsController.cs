using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElectionAutomationSystem.Models;

namespace ElectionAutomationSystem.Controllers
{
    public class PresidentsController : Controller
    {
        private ElectionDatabaseEntities db = new ElectionDatabaseEntities();

        // GET: Presidents
        public ActionResult Index()
        {
            var presidents = db.Presidents.Include(p => p.Province);
            return View(presidents.ToList());
        }

        // GET: Presidents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            President president = db.Presidents.Find(id);
            if (president == null)
            {
                return HttpNotFound();
            }
            return PartialView(president);
        }

        // GET: Presidents/Create
        public ActionResult Create()
        {
            ViewBag.BirthplaceId = new SelectList(db.Provinces, "ProvinceId", "ProvinceName");
            return PartialView();
        }

        // POST: Presidents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PresidentId,PresidentName,Birthdate,BirthplaceId,Profession")] President president)
        {
            if (ModelState.IsValid)
            {
                db.Presidents.Add(president);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BirthplaceId = new SelectList(db.Provinces, "ProvinceId", "ProvinceName", president.BirthplaceId);
            return PartialView(president);
        }

        // GET: Presidents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            President president = db.Presidents.Find(id);
            if (president == null)
            {
                return HttpNotFound();
            }
            ViewBag.BirthplaceId = new SelectList(db.Provinces, "ProvinceId", "ProvinceName", president.BirthplaceId);
            return PartialView(president);
        }

        // POST: Presidents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PresidentId,PresidentName,Birthdate,BirthplaceId,Profession")] President president)
        {
            if (ModelState.IsValid)
            {
                db.Entry(president).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BirthplaceId = new SelectList(db.Provinces, "ProvinceId", "ProvinceName", president.BirthplaceId);
            return PartialView(president);
        }

        // GET: Presidents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            President president = db.Presidents.Find(id);
            if (president == null)
            {
                return HttpNotFound();
            }
            return PartialView(president);
        }

        // POST: Presidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            President president = db.Presidents.Find(id);
            db.Presidents.Remove(president);
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
