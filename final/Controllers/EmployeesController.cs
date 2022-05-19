using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using final.Models;

namespace final.Controllers
{
    public class EmployeesController : Controller
    {
        private RegistrationEntities1 db = new RegistrationEntities1();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Details.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Details details = db.Details.Find(id);
            if (details == null)
            {
                return HttpNotFound();
            }
            return View(details);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,MobileNumber,Email,Designation,Department,OfficeLocation")] Details details)
        {
            if (ModelState.IsValid)
            {
                db.Details.Add(details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(details);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Details details = db.Details.Find(id);
            if (details == null)
            {
                return HttpNotFound();
            }
            return View(details);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,MobileNumber,Email,Designation,Department,OfficeLocation")] Details details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(details);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Details details = db.Details.Find(id);
            if (details == null)
            {
                return HttpNotFound();
            }
            return View(details);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Details details = db.Details.Find(id);
            db.Details.Remove(details);
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
