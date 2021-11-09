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
    public class PretController : Controller
    {
        private ClinicaContext db = new ClinicaContext();

        // GET: Pret
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Preturi.ToList());
        }

        // GET: Pret/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pret pret = db.Preturi.Find(id);
            if (pret == null)
            {
                return HttpNotFound();
            }
            return View(pret);
        }

        // GET: Pret/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pret/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nume,Valoare")] Pret pret)
        {
            if (ModelState.IsValid)
            {
                db.Preturi.Add(pret);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pret);
        }

        // GET: Pret/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pret pret = db.Preturi.Find(id);
            if (pret == null)
            {
                return HttpNotFound();
            }
            return View(pret);
        }

        // POST: Pret/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nume,Valoare")] Pret pret)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pret).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pret);
        }

        // GET: Pret/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pret pret = db.Preturi.Find(id);
            if (pret == null)
            {
                return HttpNotFound();
            }
            return View(pret);
        }

        // POST: Pret/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pret pret = db.Preturi.Find(id);
            db.Preturi.Remove(pret);
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
