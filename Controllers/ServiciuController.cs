using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClinicaDentalArt.DAL;
using ClinicaDentalArt.Models;

namespace ClinicaDentalArt.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiciuController : Controller
    {
        private ClinicaContext db = new ClinicaContext();

        // GET: Serviciu
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Servicii.ToList());
        }

        // GET: Serviciu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serviciu serviciu = db.Servicii.Find(id);
            if (serviciu == null)
            {
                return HttpNotFound();
            }
            return View(serviciu);
        }

        // GET: Serviciu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Serviciu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nume,Info")] Serviciu serviciu)
        {
            if (ModelState.IsValid)
            {
                db.Servicii.Add(serviciu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(serviciu);
        }

        // GET: Serviciu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serviciu serviciu = db.Servicii.Find(id);
            if (serviciu == null)
            {
                return HttpNotFound();
            }
            return View(serviciu);
        }

        // POST: Serviciu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nume,Info")] Serviciu serviciu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviciu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serviciu);
        }

        // GET: Serviciu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serviciu serviciu = db.Servicii.Find(id);
            if (serviciu == null)
            {
                return HttpNotFound();
            }
            return View(serviciu);
        }

        // POST: Serviciu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Serviciu serviciu = db.Servicii.Find(id);
            db.Servicii.Remove(serviciu);
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
