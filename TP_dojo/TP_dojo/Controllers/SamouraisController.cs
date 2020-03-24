using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BO;
using TP_dojo.Models;

namespace TP_dojo.Controllers
{
    public class SamouraisController : Controller
    {
        private Context db = new Context();

        // Method getArmesUsed
        private List<int> getArmesUsed()
        {
            return db.Samourais.Where(s => s.Arme != null).Select(s => s.Arme.Id).ToList();
        }

        // GET: Samourais
        public ActionResult Index()
        {
            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            // calcul potentiel
            ViewBag.Potentiel = (samourai.Force + (samourai.Arme == null ? 0 : samourai.Arme.Degats)) * (samourai.ArtsMartiaux.Count() > 0 ? samourai.ArtsMartiaux.Count() : 1);
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            var armesUsed = this.getArmesUsed();
            SamouraiVM samouraiVM = new SamouraiVM
            {
                Armes = db.Armes.Where(a => !armesUsed.Contains(a.Id)).ToList(),
                ArtMartiaux = db.ArtMartials.ToList()
            };
            return View(samouraiVM);
        }

        // POST: Samourais/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraiVM samouraiVM)
        {
            if (ModelState.IsValid)
            {
                if (samouraiVM.IdSelectedArme.HasValue)
                {
                    samouraiVM.Samourai.Arme = db.Armes.FirstOrDefault(a => a.Id == samouraiVM.IdSelectedArme);
                }
                samouraiVM.Samourai.ArtsMartiaux = new List<ArtMartial>();
                foreach (var idArtMartial in samouraiVM.IdSelectedArtMartiaux)
                {
                    samouraiVM.Samourai.ArtsMartiaux.Add(db.ArtMartials.Find(idArtMartial));
                }
                db.Samourais.Add(samouraiVM.Samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var armesUsed = this.getArmesUsed();
            samouraiVM.Armes = db.Armes.Where(a => !armesUsed.Contains(a.Id)).ToList();
            samouraiVM.ArtMartiaux = db.ArtMartials.ToList();
            return View(samouraiVM);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }

            var armesUsed = this.getArmesUsed();
            var samouraiVM = new SamouraiVM
            {
                Samourai = samourai,
                Armes = db.Armes.Where(a => !armesUsed.Contains(a.Id)).ToList(),
                ArtMartiaux = db.ArtMartials.ToList(),
                IdSelectedArtMartiaux = samourai.ArtsMartiaux.Select(ar => ar.Id).ToList()
            };

            if (samourai.Arme != null)
            {
                samouraiVM.IdSelectedArme = samourai.Arme.Id;
                samouraiVM.Armes.Add(samourai.Arme);
            }

            return View(samouraiVM);
        }

        // POST: Samourais/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SamouraiVM samouraiVM)
        {
            Samourai samouraiDB = db.Samourais.Find(samouraiVM.Samourai.Id);
            if (ModelState.IsValid)
            {
                if (samouraiDB.Arme != null)
                {
                    var arme = db.Armes.Find(samouraiDB.Arme.Id);
                    db.Entry(arme).State = EntityState.Modified;
                }

                samouraiDB.Arme = null;
                if (samouraiVM.IdSelectedArme.HasValue)
                {
                    samouraiDB.Arme = db.Armes.FirstOrDefault(a => a.Id == samouraiVM.IdSelectedArme);
                }
                samouraiDB.ArtsMartiaux.Clear();
                if (samouraiVM.IdSelectedArtMartiaux != null)
                {
                    foreach (var idArtMartial in samouraiVM.IdSelectedArtMartiaux)
                    {
                        samouraiDB.ArtsMartiaux.Add(db.ArtMartials.Find(idArtMartial));
                    }
                }
                samouraiDB.Nom = samouraiVM.Samourai.Nom;
                samouraiDB.Force = samouraiVM.Samourai.Force;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var armesUsed = this.getArmesUsed();
            samouraiVM.Armes = db.Armes.Where(a => !armesUsed.Contains(a.Id)).ToList();
            samouraiVM.ArtMartiaux = db.ArtMartials.ToList();
            if (samouraiDB.Arme != null)
            {
                samouraiVM.Armes.Add(samouraiDB.Arme);
            }
            return View(samouraiVM);
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
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