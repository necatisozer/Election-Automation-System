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
    public class BallotBoxesController : Controller
    {
        private ElectionDatabaseEntities db = new ElectionDatabaseEntities();

        // GET: BallotBoxes
        public ActionResult Index()
        {
            var ballotBoxes = db.BallotBoxes.Include(b => b.Neighbourhood);
            return View(ballotBoxes.ToList());
        }

        // GET: BallotBoxes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BallotBox ballotBox = db.BallotBoxes.Find(id);
            if (ballotBox == null)
            {
                return HttpNotFound();
            }
            return PartialView(ballotBox);
        }

        // GET: BallotBoxes/Create
        public ActionResult Create()
        {
            ViewBag.NeighbourhoodId = new SelectList(db.Neighbourhoods, "NeighbourhoodId", "NeighbourhoodName");
            return PartialView();
        }

        // POST: BallotBoxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BallotBoxId,BallotBoxNumber,NeighbourhoodId,VoterCount")] BallotBox ballotBox)
        {
            if (ModelState.IsValid)
            {
                db.BallotBoxes.Add(ballotBox);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NeighbourhoodId = new SelectList(db.Neighbourhoods, "NeighbourhoodId", "NeighbourhoodName", ballotBox.NeighbourhoodId);
            return PartialView(ballotBox);
        }

        // GET: BallotBoxes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BallotBox ballotBox = db.BallotBoxes.Find(id);
            if (ballotBox == null)
            {
                return HttpNotFound();
            }
            ViewBag.NeighbourhoodId = new SelectList(db.Neighbourhoods, "NeighbourhoodId", "NeighbourhoodName", ballotBox.NeighbourhoodId);
            return PartialView(ballotBox);
        }

        // POST: BallotBoxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BallotBoxId,BallotBoxNumber,NeighbourhoodId,VoterCount")] BallotBox ballotBox)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ballotBox).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NeighbourhoodId = new SelectList(db.Neighbourhoods, "NeighbourhoodId", "NeighbourhoodName", ballotBox.NeighbourhoodId);
            return PartialView(ballotBox);
        }

        // GET: BallotBoxes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BallotBox ballotBox = db.BallotBoxes.Find(id);
            if (ballotBox == null)
            {
                return HttpNotFound();
            }
            return PartialView(ballotBox);
        }

        // POST: BallotBoxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BallotBox ballotBox = db.BallotBoxes.Find(id);
            db.BallotBoxes.Remove(ballotBox);
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
