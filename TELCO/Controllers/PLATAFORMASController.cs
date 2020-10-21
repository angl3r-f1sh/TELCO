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
    public class PLATAFORMASController : Controller
    {
        private SDM db = new SDM();

        // GET: PLATAFORMAS
        public ActionResult Index()
        {
            return View(db.PLATAFORMAS.ToList());
        }

        // GET: PLATAFORMAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLATAFORMAS pLATAFORMAS = db.PLATAFORMAS.Find(id);
            if (pLATAFORMAS == null)
            {
                return HttpNotFound();
            }
            return View(pLATAFORMAS);
        }

        // GET: PLATAFORMAS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PLATAFORMAS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_plataforma,txt_plataforma")] PLATAFORMAS pLATAFORMAS)
        {
            if (ModelState.IsValid)
            {
                db.PLATAFORMAS.Add(pLATAFORMAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pLATAFORMAS);
        }

        // GET: PLATAFORMAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLATAFORMAS pLATAFORMAS = db.PLATAFORMAS.Find(id);
            if (pLATAFORMAS == null)
            {
                return HttpNotFound();
            }
            return View(pLATAFORMAS);
        }

        // POST: PLATAFORMAS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_plataforma,txt_plataforma")] PLATAFORMAS pLATAFORMAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pLATAFORMAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pLATAFORMAS);
        }

        // GET: PLATAFORMAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLATAFORMAS pLATAFORMAS = db.PLATAFORMAS.Find(id);
            if (pLATAFORMAS == null)
            {
                return HttpNotFound();
            }
            return View(pLATAFORMAS);
        }

        // POST: PLATAFORMAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PLATAFORMAS pLATAFORMAS = db.PLATAFORMAS.Find(id);
            db.PLATAFORMAS.Remove(pLATAFORMAS);
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
