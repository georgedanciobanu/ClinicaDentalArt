using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ClinicaDentalArt.DAL;
using ClinicaDentalArt.Models;

namespace ClinicaDentalArt.Controllers
{
    [Authorize(Roles ="Admin")]
    public class EchipaController : Controller
    {
        private ClinicaContext db = new ClinicaContext();

        // GET: Echipa
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Echipe.ToList());
        }

        // GET: Echipa/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Echipa echipa = db.Echipe.Find(id);
            if (echipa == null)
            {
                return HttpNotFound();
            }
            return View(echipa);
        }

        // GET: Echipa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Echipa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EchipaID,Nume,Specializare")] Echipa echipa)
        {
            if (ModelState.IsValid)
            {
                db.Echipe.Add(echipa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(echipa);
        }

        // GET: Echipa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Echipa echipa = db.Echipe.Find(id);
            if (echipa == null)
            {
                return HttpNotFound();
            }
            return View(echipa);
        }

        // POST: Echipa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EchipaID,Nume,Specializare")] Echipa echipa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(echipa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(echipa);
        }

        // GET: Echipa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Echipa echipa = db.Echipe.Find(id);
            if (echipa == null)
            {
                return HttpNotFound();
            }
            return View(echipa);
        }

        // POST: Echipa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Echipa echipa = db.Echipe.Find(id);
            db.Echipe.Remove(echipa);
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
