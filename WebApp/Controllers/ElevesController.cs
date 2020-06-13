using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.ProjectNet;
using Model.ProjectNet.Entities;

namespace WebApp.Controllers
{
    public class ElevesController : Controller
    {
        private ProNetDbContext db = new ProNetDbContext();

        // GET: Eleves
        public async Task<ActionResult> Index()
        {
            var eleves = db.Eleves.Include(e => e.Classe);
            return View(await eleves.ToListAsync());
        }

        // GET: Eleves/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eleve eleve = await db.Eleves.Include(e => e.Classe).FirstOrDefaultAsync(e => e.Id == id.Value);
            if (eleve == null)
            {
                return HttpNotFound();
            }
            return View(eleve);
        }

        // GET: Eleves/Create
        public ActionResult Create()
        {
            ViewBag.ClasseId = new SelectList(db.Classes, "Id", "NomEtablissement");
            return View();
        }

        // POST: Eleves/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nom,Prenom,DateNaissance,ClasseId")] Eleve eleve)
        {
            if (ModelState.IsValid)
            {
                db.Eleves.Add(eleve);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClasseId = new SelectList(db.Classes, "Id", "NomEtablissement", eleve.ClasseId);
            return View(eleve);
        }

        // GET: Eleves/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eleve eleve = await db.Eleves.FindAsync(id);
            if (eleve == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClasseId = new SelectList(db.Classes, "Id", "NomEtablissement", eleve.ClasseId);
            return View(eleve);
        }

        // POST: Eleves/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nom,Prenom,DateNaissance,ClasseId")] Eleve eleve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eleve).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClasseId = new SelectList(db.Classes, "Id", "NomEtablissement", eleve.ClasseId);
            return View(eleve);
        }

        // GET: Eleves/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eleve eleve = await db.Eleves.FindAsync(id);
            if (eleve == null)
            {
                return HttpNotFound();
            }
            return View(eleve);
        }

        // POST: Eleves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Eleve eleve = await db.Eleves.FindAsync(id);
            db.Eleves.Remove(eleve);
            await db.SaveChangesAsync();
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
