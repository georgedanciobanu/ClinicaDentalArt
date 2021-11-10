using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ClinicaDentalArt.DAL;
using ClinicaDentalArt.Models;
using ClinicaDentalArt.ViewModels;

namespace ClinicaDentalArt.Controllers
{
    public class ProgramareController : Controller
    {
        private ClinicaContext db = new ClinicaContext();

        // GET: Programare
        [AllowAnonymous]
        public ActionResult Index(string sortOrder)
        {
            ViewBag.Echipe = db.Echipe.ToList();
            ViewBag.DataSortParam = sortOrder == "Data" ? "data_desc" : "Data";
            var programari = from p in db.Programari select p;
            switch(sortOrder)
            {
                case "Data":
                    programari = programari.OrderBy(p => p.Data);
                    break;
                case "data_desc":
                    programari = programari.OrderByDescending(p => p.Data);
                    break;
                default:
                    programari = programari.OrderBy(p => p.ID);
                    break;
            }
            return View(programari.ToList());
            
            //return View(db.Programari.ToList());
        }

        // GET: Programare/Details/5
        [Authorize(Roles = "User, Admin")]
        public ActionResult Details(int? id)
        {
            ViewBag.Echipe = db.Echipe.ToList();
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programare programare = db.Programari.Find(id);
            if (programare == null)
            {
                return HttpNotFound();
            }
            return View(programare);
        }

        // GET: Programare/Create
        [Authorize(Roles = "User, Admin")]
        public ActionResult Create()
        {
            ViewBag.Tratament = new SelectList(db.Servicii, null, "Nume");
            ViewBag.EchipaID = new SelectList(db.Echipe, "EchipaID", "Nume");
            return View();
        }

        // POST: Programare/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User, Admin")]
        public ActionResult Create([Bind(Include = "ID,Nume,Prenume,Tratament,Data,Telefon,Email,EchipaID,Comment,Tags")] Programare programare)
        {
            ViewBag.Tratament = new SelectList(db.Servicii, null, "Nume");
            ViewBag.EchipaID = new SelectList(db.Echipe, "EchipaID", "Nume");

            if (ModelState.IsValid)
            {
                try
                {
                    if (User.Identity.IsAuthenticated)
                    {

                        programare.Tags = User.Identity.Name;
                        
                    }
                    
                    db.Programari.Add(programare);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View("Index");
                }
            }

            return View(programare);
        }

        // GET: Programare/Edit/5
        [Authorize(Roles = "User, Admin")]
        public ActionResult Edit(int? id)
        {
            ViewBag.Tratament = new SelectList(db.Servicii, null, "Nume");
            ViewBag.EchipaID = new SelectList(db.Echipe, "EchipaID", "Nume");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programare programare = db.Programari.Find(id);
            if (programare == null)
            {
                return HttpNotFound();
            }
            return View(programare);
        }

        // POST: Programare/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User, Admin")]
        public ActionResult Edit([Bind(Include = "ID,Nume,Prenume,Tratament,Data,Telefon,Email,EchipaID,Comment,Tags")] Programare programare)
        {
            ViewBag.Tratament = new SelectList(db.Servicii, null, "Nume");
            ViewBag.EchipaID = new SelectList(db.Echipe, "EchipaID", "Nume");

            if (ModelState.IsValid)
            {
                try
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        if (User.IsInRole("User"))
                        {
                            programare.Tags =  User.Identity.Name;
                        }
                        if (User.IsInRole("Admin"))
                        {
                            
                        }
                    }

                    db.Entry(programare).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View("Index");
                }
            }
            return View(programare);
        }

        // GET: Programare/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EchipaProgramare echipaProgramare = new EchipaProgramare();
            Programare programare = db.Programari.Find(id);
            
            if (programare == null)
            {
                return HttpNotFound();
            }

            echipaProgramare.Nume = programare.Nume;
            echipaProgramare.Prenume = programare.Prenume;
            echipaProgramare.Serviciu = programare.Tratament;
            echipaProgramare.Data = programare.Data;
            echipaProgramare.Telefon = programare.Telefon;
            echipaProgramare.Email = programare.Email;
            echipaProgramare.Mesaj = programare.Comment;

            foreach (var e in db.Echipe)
            {
                if (e.EchipaID == programare.EchipaID)
                {
                    echipaProgramare.NumeMedic = e.Nume;
                }
            }
            return View(echipaProgramare);
        }

        // POST: Programare/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Programare programare = db.Programari.Find(id);
            db.Programari.Remove(programare);
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
