using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SIRERH.Models
{
    public class DETALLEsController : Controller
    {
        private Proyecto_P5Entities db = new Proyecto_P5Entities();

        // GET: DETALLEs
        public ActionResult Index()
        {
            var dETALLE = db.DETALLE.Include(d => d.TECNOLOGIA);
            return View(dETALLE.ToList());
        }

        // GET: DETALLEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE dETALLE = db.DETALLE.Find(id);
            if (dETALLE == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE);
        }

        // GET: DETALLEs/Create
        public ActionResult Create()
        {
            ViewBag.ID_TECNOLOGIA = new SelectList(db.TECNOLOGIA, "ID_TECNOLOGIA", "TECNOLOGIA1");
            return View();
        }

        // POST: DETALLEs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DETALLE,EXPERIENCIA,GRADO_ACADEMICO,ID_TECNOLOGIA")] DETALLE dETALLE)
        {
            if (ModelState.IsValid)
            {
                db.DETALLE.Add(dETALLE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_TECNOLOGIA = new SelectList(db.TECNOLOGIA, "ID_TECNOLOGIA", "TECNOLOGIA1", dETALLE.ID_TECNOLOGIA);
            return View(dETALLE);
        }

        // GET: DETALLEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE dETALLE = db.DETALLE.Find(id);
            if (dETALLE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_TECNOLOGIA = new SelectList(db.TECNOLOGIA, "ID_TECNOLOGIA", "TECNOLOGIA1", dETALLE.ID_TECNOLOGIA);
            return View(dETALLE);
        }

        // POST: DETALLEs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DETALLE,EXPERIENCIA,GRADO_ACADEMICO,ID_TECNOLOGIA")] DETALLE dETALLE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETALLE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_TECNOLOGIA = new SelectList(db.TECNOLOGIA, "ID_TECNOLOGIA", "TECNOLOGIA1", dETALLE.ID_TECNOLOGIA);
            return View(dETALLE);
        }

        // GET: DETALLEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE dETALLE = db.DETALLE.Find(id);
            if (dETALLE == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE);
        }

        // POST: DETALLEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DETALLE dETALLE = db.DETALLE.Find(id);
            db.DETALLE.Remove(dETALLE);
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
