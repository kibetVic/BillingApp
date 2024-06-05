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
    public class OnlineReceiptingsController : Controller
    {
        private BillingDBEntities db = new BillingDBEntities();

        // GET: OnlineReceiptings
        public ActionResult Index()
        {
            var onlineReceiptings = db.OnlineReceiptings.Include(o => o.Billing);
            return View(onlineReceiptings.ToList());
        }

        // GET: OnlineReceiptings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OnlineReceipting onlineReceipting = db.OnlineReceiptings.Find(id);
            if (onlineReceipting == null)
            {
                return HttpNotFound();
            }
            return View(onlineReceipting);
        }

        // GET: OnlineReceiptings/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Billings, "BillId", "ReferenceId");
            return View();
        }

        // POST: OnlineReceiptings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReceiptId,ReceiptNumber,Timestamp,CustomerId,CustomerName,PaymentMethod,PaymentAmount,BillingPeriodStart,BillingPeriodEnd,BillId,Remarks,ProcceessedBy")] OnlineReceipting onlineReceipting)
        {
            if (ModelState.IsValid)
            {
                db.OnlineReceiptings.Add(onlineReceipting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Billings, "BillId", "ReferenceId", onlineReceipting.CustomerId);
            return View(onlineReceipting);
        }

        // GET: OnlineReceiptings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OnlineReceipting onlineReceipting = db.OnlineReceiptings.Find(id);
            if (onlineReceipting == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Billings, "BillId", "ReferenceId", onlineReceipting.CustomerId);
            return View(onlineReceipting);
        }

        // POST: OnlineReceiptings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReceiptId,ReceiptNumber,Timestamp,CustomerId,CustomerName,PaymentMethod,PaymentAmount,BillingPeriodStart,BillingPeriodEnd,BillId,Remarks,ProcceessedBy")] OnlineReceipting onlineReceipting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(onlineReceipting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Billings, "BillId", "ReferenceId", onlineReceipting.CustomerId);
            return View(onlineReceipting);
        }

        // GET: OnlineReceiptings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OnlineReceipting onlineReceipting = db.OnlineReceiptings.Find(id);
            if (onlineReceipting == null)
            {
                return HttpNotFound();
            }
            return View(onlineReceipting);
        }

        // POST: OnlineReceiptings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OnlineReceipting onlineReceipting = db.OnlineReceiptings.Find(id);
            db.OnlineReceiptings.Remove(onlineReceipting);
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
