using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using fortune_teller_mvc.Models;

namespace fortune_teller_mvc.Controllers
{
    public class CustomerIDsController : Controller
    {
        private FortuneTellerMVCEntities db = new FortuneTellerMVCEntities();

        // GET: CustomerIDs
        public ActionResult Index()
        {
            return View(db.CustomerIDs.ToList());
        }

        // GET: CustomerIDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerID customerID = db.CustomerIDs.Find(id);
            if (customerID == null)
            {
                return HttpNotFound();
            }
            return View(customerID);
        }

        // GET: CustomerIDs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerIDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID1,FirstName,LastName,Age,BirthMonth,FavoriteColor,NumberOfSiblings")] CustomerID customerID)
        {
            if (ModelState.IsValid)
            {
                db.CustomerIDs.Add(customerID);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerID);
        }

        // GET: CustomerIDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerID customerID = db.CustomerIDs.Find(id);
            if (customerID == null)
            {
                return HttpNotFound();
            }
            return View(customerID);
        }

        // POST: CustomerIDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID1,FirstName,LastName,Age,BirthMonth,FavoriteColor,NumberOfSiblings")] CustomerID customerID)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerID).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerID);
        }

        // GET: CustomerIDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerID customerID = db.CustomerIDs.Find(id);
            if (customerID == null)
            {
                return HttpNotFound();
            }
            return View(customerID);
        }

        // POST: CustomerIDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerID customerID = db.CustomerIDs.Find(id);
            db.CustomerIDs.Remove(customerID);
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
