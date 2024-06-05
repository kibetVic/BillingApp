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
    public class MetersController : Controller
    {
        private BillingDBEntities db = new BillingDBEntities();

        // GET: Meters
        public ActionResult Index()
        {
            return View(db.Meters.ToList());
        }

        // GET: Meters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meter meter = db.Meters.Find(id);
            if (meter == null)
            {
                return HttpNotFound();
            }
            return View(meter);
        }

        // GET: Meters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MeterId,MeterNo,CustomerId,GPRS,Date,MeterHistory")] Meter meter)
        {
            if (ModelState.IsValid)
            {
                db.Meters.Add(meter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meter);
        }

        // GET: Meters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meter meter = db.Meters.Find(id);
            if (meter == null)
            {
                return HttpNotFound();
            }
            return View(meter);
        }

        // POST: Meters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MeterId,MeterNo,CustomerId,GPRS,Date,MeterHistory")] Meter meter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meter);
        }

        // GET: Meters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meter meter = db.Meters.Find(id);
            if (meter == null)
            {
                return HttpNotFound();
            }
            return View(meter);
        }

        // POST: Meters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meter meter = db.Meters.Find(id);
            db.Meters.Remove(meter);
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
