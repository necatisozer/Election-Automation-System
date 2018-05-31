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
    public class NeighbourhoodsController : Controller
    {
        private ElectionDatabaseEntities db = new ElectionDatabaseEntities();

        // GET: Neighbourhoods
        public ActionResult Index()
        {
            var neighbourhoods = db.Neighbourhoods.Include(n => n.District);
            return View(neighbourhoods.ToList());
        }

        // GET: Neighbourhoods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neighbourhood neighbourhood = db.Neighbourhoods.Find(id);
            if (neighbourhood == null)
            {
                return HttpNotFound();
            }
            return PartialView(neighbourhood);
        }

        // GET: Neighbourhoods/Create
        public ActionResult Create()
        {
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "DistrictName");
            return PartialView();
        }

        // POST: Neighbourhoods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NeighbourhoodId,NeighbourhoodName,DistrictId")] Neighbourhood neighbourhood)
        {
            if (ModelState.IsValid)
            {
                db.Neighbourhoods.Add(neighbourhood);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "DistrictName", neighbourhood.DistrictId);
            return PartialView(neighbourhood);
        }

        // GET: Neighbourhoods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neighbourhood neighbourhood = db.Neighbourhoods.Find(id);
            if (neighbourhood == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "DistrictName", neighbourhood.DistrictId);
            return PartialView(neighbourhood);
        }

        // POST: Neighbourhoods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NeighbourhoodId,NeighbourhoodName,DistrictId")] Neighbourhood neighbourhood)
        {
            if (ModelState.IsValid)
            {
                db.Entry(neighbourhood).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "DistrictName", neighbourhood.DistrictId);
            return PartialView(neighbourhood);
        }

        // GET: Neighbourhoods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neighbourhood neighbourhood = db.Neighbourhoods.Find(id);
            if (neighbourhood == null)
            {
                return HttpNotFound();
            }
            return PartialView(neighbourhood);
        }

        // POST: Neighbourhoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Neighbourhood neighbourhood = db.Neighbourhoods.Find(id);
            db.Neighbourhoods.Remove(neighbourhood);
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
