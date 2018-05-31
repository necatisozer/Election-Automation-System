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
    public class VotesController : Controller
    {
        private ElectionDatabaseEntities db = new ElectionDatabaseEntities();

        // GET: Votes
        public ActionResult Index()
        {
            var votes = db.Votes.Include(v => v.BallotBox).Include(v => v.Party);
            return View(votes.ToList());
        }

        // GET: Votes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vote vote = db.Votes.Find(id);
            if (vote == null)
            {
                return HttpNotFound();
            }
            return PartialView(vote);
        }

        // GET: Votes/Create
        public ActionResult Create()
        {
            ViewBag.BallotBoxId = new SelectList(db.BallotBoxes, "BallotBoxId", "BallotBoxNumber");
            ViewBag.PartyId = new SelectList(db.Parties, "PartyId", "PartyName");
            return PartialView();
        }

        // POST: Votes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VoteId,BallotBoxId,PartyId,VoteCount")] Vote vote)
        {
            if (ModelState.IsValid)
            {
                db.Votes.Add(vote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BallotBoxId = new SelectList(db.BallotBoxes, "BallotBoxId", "BallotBoxId", vote.BallotBoxId);
            ViewBag.PartyId = new SelectList(db.Parties, "PartyId", "PartyName", vote.PartyId);
            return PartialView(vote);
        }

        // GET: Votes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vote vote = db.Votes.Find(id);
            if (vote == null)
            {
                return HttpNotFound();
            }
            ViewBag.BallotBoxId = new SelectList(db.BallotBoxes, "BallotBoxId", "BallotBoxId", vote.BallotBoxId);
            ViewBag.PartyId = new SelectList(db.Parties, "PartyId", "PartyName", vote.PartyId);
            return PartialView(vote);
        }

        // POST: Votes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VoteId,BallotBoxId,PartyId,VoteCount")] Vote vote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BallotBoxId = new SelectList(db.BallotBoxes, "BallotBoxId", "BallotBoxId", vote.BallotBoxId);
            ViewBag.PartyId = new SelectList(db.Parties, "PartyId", "PartyName", vote.PartyId);
            return PartialView(vote);
        }

        // GET: Votes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vote vote = db.Votes.Find(id);
            if (vote == null)
            {
                return HttpNotFound();
            }
            return PartialView(vote);
        }

        // POST: Votes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vote vote = db.Votes.Find(id);
            db.Votes.Remove(vote);
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
