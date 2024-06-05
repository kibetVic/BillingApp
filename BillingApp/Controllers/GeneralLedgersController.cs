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
    public class GeneralLedgersController : Controller
    {
        private BillingDBEntities db = new BillingDBEntities();

        // GET: GeneralLedgers
        public ActionResult Index()
        {
            var generalLedgers = db.GeneralLedgers.Include(g => g.Billing).Include(g => g.User);
            return View(generalLedgers.ToList());
        }

        // GET: GeneralLedgers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralLedger generalLedger = db.GeneralLedgers.Find(id);
            if (generalLedger == null)
            {
                return HttpNotFound();
            }
            return View(generalLedger);
        }

        // GET: GeneralLedgers/Create
        public ActionResult Create()
        {
            ViewBag.BillId = new SelectList(db.Billings, "BillId", "ReferenceId");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName");
            return View();
        }

        // POST: GeneralLedgers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransactionId,BillId,TransactionDate,Description,DebitAccount,CreditAccount,Amount,ReferenceId,UserId,Remarks,AuditDatetime")] GeneralLedger generalLedger)
        {
            if (ModelState.IsValid)
            {
                db.GeneralLedgers.Add(generalLedger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BillId = new SelectList(db.Billings, "BillId", "ReferenceId", generalLedger.BillId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", generalLedger.UserId);
            return View(generalLedger);
        }

        // GET: GeneralLedgers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralLedger generalLedger = db.GeneralLedgers.Find(id);
            if (generalLedger == null)
            {
                return HttpNotFound();
            }
            ViewBag.BillId = new SelectList(db.Billings, "BillId", "ReferenceId", generalLedger.BillId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", generalLedger.UserId);
            return View(generalLedger);
        }

        // POST: GeneralLedgers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransactionId,BillId,TransactionDate,Description,DebitAccount,CreditAccount,Amount,ReferenceId,UserId,Remarks,AuditDatetime")] GeneralLedger generalLedger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(generalLedger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BillId = new SelectList(db.Billings, "BillId", "ReferenceId", generalLedger.BillId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", generalLedger.UserId);
            return View(generalLedger);
        }

        // GET: GeneralLedgers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralLedger generalLedger = db.GeneralLedgers.Find(id);
            if (generalLedger == null)
            {
                return HttpNotFound();
            }
            return View(generalLedger);
        }

        // POST: GeneralLedgers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GeneralLedger generalLedger = db.GeneralLedgers.Find(id);
            db.GeneralLedgers.Remove(generalLedger);
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
