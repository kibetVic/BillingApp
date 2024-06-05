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
    public class CustomersController : Controller
    {
        private BillingDBEntities db = new BillingDBEntities();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.Audit).Include(c => c.Audit1).Include(c => c.Billing).Include(c => c.Message).Include(c => c.Meter).Include(c => c.OnlineReceipting);
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.AuditId = new SelectList(db.Audits, "AuditId", "OperationType");
            ViewBag.AuditId = new SelectList(db.Audits, "AuditId", "OperationType");
            ViewBag.CustomerId = new SelectList(db.Billings, "BillId", "ReferenceId");
            ViewBag.CustomerId = new SelectList(db.Messages, "MessageId", "PhoneNumber");
            ViewBag.MeterNo = new SelectList(db.Meters, "MeterId", "MeterHistory");
            ViewBag.CustomerId = new SelectList(db.OnlineReceiptings, "ReceiptId", "CustomerName");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,IDNumber,FirstName,MidleName,LastName,Email,PhoneNumber,County,SubCounty,Location,Village,RegistrationDate,MeterNo,CompanyCode,AuditId,AuditDateTime")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuditId = new SelectList(db.Audits, "AuditId", "OperationType", customer.AuditId);
            ViewBag.AuditId = new SelectList(db.Audits, "AuditId", "OperationType", customer.AuditId);
            ViewBag.CustomerId = new SelectList(db.Billings, "BillId", "ReferenceId", customer.CustomerId);
            ViewBag.CustomerId = new SelectList(db.Messages, "MessageId", "PhoneNumber", customer.CustomerId);
            ViewBag.MeterNo = new SelectList(db.Meters, "MeterId", "MeterHistory", customer.MeterNo);
            ViewBag.CustomerId = new SelectList(db.OnlineReceiptings, "ReceiptId", "CustomerName", customer.CustomerId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuditId = new SelectList(db.Audits, "AuditId", "OperationType", customer.AuditId);
            ViewBag.AuditId = new SelectList(db.Audits, "AuditId", "OperationType", customer.AuditId);
            ViewBag.CustomerId = new SelectList(db.Billings, "BillId", "ReferenceId", customer.CustomerId);
            ViewBag.CustomerId = new SelectList(db.Messages, "MessageId", "PhoneNumber", customer.CustomerId);
            ViewBag.MeterNo = new SelectList(db.Meters, "MeterId", "MeterHistory", customer.MeterNo);
            ViewBag.CustomerId = new SelectList(db.OnlineReceiptings, "ReceiptId", "CustomerName", customer.CustomerId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,IDNumber,FirstName,MidleName,LastName,Email,PhoneNumber,County,SubCounty,Location,Village,RegistrationDate,MeterNo,CompanyCode,AuditId,AuditDateTime")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuditId = new SelectList(db.Audits, "AuditId", "OperationType", customer.AuditId);
            ViewBag.AuditId = new SelectList(db.Audits, "AuditId", "OperationType", customer.AuditId);
            ViewBag.CustomerId = new SelectList(db.Billings, "BillId", "ReferenceId", customer.CustomerId);
            ViewBag.CustomerId = new SelectList(db.Messages, "MessageId", "PhoneNumber", customer.CustomerId);
            ViewBag.MeterNo = new SelectList(db.Meters, "MeterId", "MeterHistory", customer.MeterNo);
            ViewBag.CustomerId = new SelectList(db.OnlineReceiptings, "ReceiptId", "CustomerName", customer.CustomerId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
