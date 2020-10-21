using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TELCO.Models.BD;

namespace TELCO.Controllers
{
    public class GENEROSController : Controller
    {
        private SDM db = new SDM();

        // GET: GENEROS
        public ActionResult Index()
        {
            return View(db.GENEROS.ToList());
        }

        // GET: GENEROS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GENEROS gENEROS = db.GENEROS.Find(id);
            if (gENEROS == null)
            {
                return HttpNotFound();
            }
            return View(gENEROS);
        }

        // GET: GENEROS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GENEROS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_genero,txt_genero")] GENEROS gENEROS)
        {
            if (ModelState.IsValid)
            {
                db.GENEROS.Add(gENEROS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gENEROS);
        }

        // GET: GENEROS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GENEROS gENEROS = db.GENEROS.Find(id);
            if (gENEROS == null)
            {
                return HttpNotFound();
            }
            return View(gENEROS);
        }

        // POST: GENEROS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_genero,txt_genero")] GENEROS gENEROS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gENEROS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gENEROS);
        }

        // GET: GENEROS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GENEROS gENEROS = db.GENEROS.Find(id);
            if (gENEROS == null)
            {
                return HttpNotFound();
            }
            return View(gENEROS);
        }

        // POST: GENEROS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GENEROS gENEROS = db.GENEROS.Find(id);
            db.GENEROS.Remove(gENEROS);
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
