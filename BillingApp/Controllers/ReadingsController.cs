using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BillingApp.Models;

namespace BillingApp.Controllers
{
    public class ReadingsController : Controller
    {
        private BillingDBEntities db = new BillingDBEntities();

        // GET: Readings
        public ActionResult Index()
        {
            var readings = db.Readings.Include(r => r.Meter).Include(r => r.User).Include(r => r.User1);
            return View(readings.ToList());
        }

        // GET: Readings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reading reading = db.Readings.Find(id);
            if (reading == null)
            {
                return HttpNotFound();
            }
            return View(reading);
        }

        // GET: Readings/Create
        public ActionResult Create()
        {
            ViewBag.MeterId = new SelectList(db.Meters, "MeterId", "MeterHistory");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName");
            return View();
        }

        // POST: Readings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReadingId,MeterId,Readingdate,MeterReading,UserId")] Reading reading)
        {
            if (ModelState.IsValid)
            {
                db.Readings.Add(reading);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MeterId = new SelectList(db.Meters, "MeterId", "MeterHistory", reading.MeterId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", reading.UserId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", reading.UserId);
            return View(reading);
        }

        // GET: Readings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reading reading = db.Readings.Find(id);
            if (reading == null)
            {
                return HttpNotFound();
            }
            ViewBag.MeterId = new SelectList(db.Meters, "MeterId", "MeterHistory", reading.MeterId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", reading.UserId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", reading.UserId);
            return View(reading);
        }

        // POST: Readings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReadingId,MeterId,Readingdate,MeterReading,UserId")] Reading reading)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reading).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MeterId = new SelectList(db.Meters, "MeterId", "MeterHistory", reading.MeterId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", reading.UserId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", reading.UserId);
            return View(reading);
        }

        // GET: Readings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reading reading = db.Readings.Find(id);
            if (reading == null)
            {
                return HttpNotFound();
            }
            return View(reading);
        }

        // POST: Readings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reading reading = db.Readings.Find(id);
            db.Readings.Remove(reading);
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
