﻿using System;
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
    public class PartiesController : Controller
    {
        private ElectionDatabaseEntities db = new ElectionDatabaseEntities();

        // GET: Parties
        public ActionResult Index()
        {
            var parties = db.Parties.Include(p => p.President).Include(p => p.Province);
            return View(parties.ToList());
        }

        // GET: Parties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Party party = db.Parties.Find(id);
            if (party == null)
            {
                return HttpNotFound();
            }
            return PartialView(party);
        }

        // GET: Parties/Create
        public ActionResult Create()
        {
            ViewBag.PresidentId = new SelectList(db.Presidents, "PresidentId", "PresidentName");
            ViewBag.HeadquartersId = new SelectList(db.Provinces, "ProvinceId", "ProvinceName");
            return PartialView();
        }

        // POST: Parties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PartyId,PartyName,PresidentId,Founder,FoundationDate,HeadquartersId,IsParty")] Party party)
        {
            if (ModelState.IsValid)
            {
                db.Parties.Add(party);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PresidentId = new SelectList(db.Presidents, "PresidentId", "PresidentName", party.PresidentId);
            ViewBag.HeadquartersId = new SelectList(db.Provinces, "ProvinceId", "ProvinceName", party.HeadquartersId);
            return PartialView(party);
        }

        // GET: Parties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Party party = db.Parties.Find(id);
            if (party == null)
            {
                return HttpNotFound();
            }
            ViewBag.PresidentId = new SelectList(db.Presidents, "PresidentId", "PresidentName", party.PresidentId);
            ViewBag.HeadquartersId = new SelectList(db.Provinces, "ProvinceId", "ProvinceName", party.HeadquartersId);
            return PartialView(party);
        }

        // POST: Parties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PartyId,PartyName,PresidentId,Founder,FoundationDate,HeadquartersId,IsParty")] Party party)
        {
            if (ModelState.IsValid)
            {
                db.Entry(party).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PresidentId = new SelectList(db.Presidents, "PresidentId", "PresidentName", party.PresidentId);
            ViewBag.HeadquartersId = new SelectList(db.Provinces, "ProvinceId", "ProvinceName", party.HeadquartersId);
            return PartialView(party);
        }

        // GET: Parties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Party party = db.Parties.Find(id);
            if (party == null)
            {
                return HttpNotFound();
            }
            return PartialView(party);
        }

        // POST: Parties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Party party = db.Parties.Find(id);
            db.Parties.Remove(party);
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
