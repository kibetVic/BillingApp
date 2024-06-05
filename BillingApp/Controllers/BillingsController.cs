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
    public class BillingsController : Controller
    {
        private BillingDBEntities db = new BillingDBEntities();

        // GET: Billings
        public ActionResult Index()
        {
            var billings = db.Billings.Include(b => b.Meter).Include(b => b.User);
            return View(billings.ToList());
        }

        // GET: Billings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Billing billing = db.Billings.Find(id);
            if (billing == null)
            {
                return HttpNotFound();
            }
            return View(billing);
        }

        // GET: Billings/Create
        public ActionResult Create()
        {
            ViewBag.MeterNo = new SelectList(db.Meters, "MeterId", "MeterHistory");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName");
            return View();
        }

        // POST: Billings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BillId,CustomerId,MeterNo,ReferenceId,ReadingDate,PreviousReading,CurrentReading,UnitConsumed,Rate,CurrentBill,Balance,CreditApplied,StdCharges,TotalOutStanding,Duedate,UserId,AuditdateTime")] Billing billing)
        {
            if (ModelState.IsValid)
            {
                db.Billings.Add(billing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MeterNo = new SelectList(db.Meters, "MeterId", "MeterHistory", billing.MeterNo);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", billing.UserId);
            return View(billing);
        }

        // GET: Billings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Billing billing = db.Billings.Find(id);
            if (billing == null)
            {
                return HttpNotFound();
            }
            ViewBag.MeterNo = new SelectList(db.Meters, "MeterId", "MeterHistory", billing.MeterNo);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", billing.UserId);
            return View(billing);
        }

        // POST: Billings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BillId,CustomerId,MeterNo,ReferenceId,ReadingDate,PreviousReading,CurrentReading,UnitConsumed,Rate,CurrentBill,Balance,CreditApplied,StdCharges,TotalOutStanding,Duedate,UserId,AuditdateTime")] Billing billing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MeterNo = new SelectList(db.Meters, "MeterId", "MeterHistory", billing.MeterNo);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", billing.UserId);
            return View(billing);
        }

        // GET: Billings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Billing billing = db.Billings.Find(id);
            if (billing == null)
            {
                return HttpNotFound();
            }
            return View(billing);
        }

        // POST: Billings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Billing billing = db.Billings.Find(id);
            db.Billings.Remove(billing);
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
