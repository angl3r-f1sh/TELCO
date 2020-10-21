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
    public class VIDEOJUEGOSController : Controller
    {
        private SDM db = new SDM();

        // GET: VIDEOJUEGOS
        public ActionResult Index()
        {
            var vIDEOJUEGOS = db.VIDEOJUEGOS.Include(v => v.GENEROS).Include(v => v.PLATAFORMAS);
            return View(vIDEOJUEGOS.ToList());
        }

        // GET: VIDEOJUEGOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIDEOJUEGOS vIDEOJUEGOS = db.VIDEOJUEGOS.Find(id);
            if (vIDEOJUEGOS == null)
            {
                return HttpNotFound();
            }
            return View(vIDEOJUEGOS);
        }

        // GET: VIDEOJUEGOS/Create
        public ActionResult Create()
        {
            ViewBag.cod_genero = new SelectList(db.GENEROS, "cod_genero", "txt_genero");
            ViewBag.cod_plataforma = new SelectList(db.PLATAFORMAS, "cod_plataforma", "txt_plataforma");
            return View();
        }

        // POST: VIDEOJUEGOS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_videojuego,txt_nombre,txt_descripcion,fec_lanzamiento,cod_plataforma,cod_genero")] VIDEOJUEGOS vIDEOJUEGOS)
        {
            if (ModelState.IsValid)
            {
                db.VIDEOJUEGOS.Add(vIDEOJUEGOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_genero = new SelectList(db.GENEROS, "cod_genero", "txt_genero", vIDEOJUEGOS.cod_genero);
            ViewBag.cod_plataforma = new SelectList(db.PLATAFORMAS, "cod_plataforma", "txt_plataforma", vIDEOJUEGOS.cod_plataforma);
            return View(vIDEOJUEGOS);
        }

        // GET: VIDEOJUEGOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIDEOJUEGOS vIDEOJUEGOS = db.VIDEOJUEGOS.Find(id);
            if (vIDEOJUEGOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_genero = new SelectList(db.GENEROS, "cod_genero", "txt_genero", vIDEOJUEGOS.cod_genero);
            ViewBag.cod_plataforma = new SelectList(db.PLATAFORMAS, "cod_plataforma", "txt_plataforma", vIDEOJUEGOS.cod_plataforma);
            return View(vIDEOJUEGOS);
        }

        // POST: VIDEOJUEGOS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_videojuego,txt_nombre,txt_descripcion,fec_lanzamiento,cod_plataforma,cod_genero")] VIDEOJUEGOS vIDEOJUEGOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vIDEOJUEGOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_genero = new SelectList(db.GENEROS, "cod_genero", "txt_genero", vIDEOJUEGOS.cod_genero);
            ViewBag.cod_plataforma = new SelectList(db.PLATAFORMAS, "cod_plataforma", "txt_plataforma", vIDEOJUEGOS.cod_plataforma);
            return View(vIDEOJUEGOS);
        }

        // GET: VIDEOJUEGOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIDEOJUEGOS vIDEOJUEGOS = db.VIDEOJUEGOS.Find(id);
            if (vIDEOJUEGOS == null)
            {
                return HttpNotFound();
            }
            return View(vIDEOJUEGOS);
        }

        // POST: VIDEOJUEGOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VIDEOJUEGOS vIDEOJUEGOS = db.VIDEOJUEGOS.Find(id);
            db.VIDEOJUEGOS.Remove(vIDEOJUEGOS);
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
