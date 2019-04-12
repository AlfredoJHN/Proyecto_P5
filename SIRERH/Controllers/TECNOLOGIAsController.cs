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
    public class TECNOLOGIAsController : Controller
    {
        private Proyecto_P5Entities db = new Proyecto_P5Entities();

        // GET: TECNOLOGIAs
        public ActionResult Index()
        {
            return View(db.TECNOLOGIA.ToList());
        }

        // GET: TECNOLOGIAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TECNOLOGIA tECNOLOGIA = db.TECNOLOGIA.Find(id);
            if (tECNOLOGIA == null)
            {
                return HttpNotFound();
            }
            return View(tECNOLOGIA);
        }

        // GET: TECNOLOGIAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TECNOLOGIAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TECNOLOGIA,TECNOLOGIA1")] TECNOLOGIA tECNOLOGIA)
        {
            if (ModelState.IsValid)
            {
                db.TECNOLOGIA.Add(tECNOLOGIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tECNOLOGIA);
        }

        // GET: TECNOLOGIAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TECNOLOGIA tECNOLOGIA = db.TECNOLOGIA.Find(id);
            if (tECNOLOGIA == null)
            {
                return HttpNotFound();
            }
            return View(tECNOLOGIA);
        }

        // POST: TECNOLOGIAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TECNOLOGIA,TECNOLOGIA1")] TECNOLOGIA tECNOLOGIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tECNOLOGIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tECNOLOGIA);
        }

        // GET: TECNOLOGIAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TECNOLOGIA tECNOLOGIA = db.TECNOLOGIA.Find(id);
            if (tECNOLOGIA == null)
            {
                return HttpNotFound();
            }
            return View(tECNOLOGIA);
        }

        // POST: TECNOLOGIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TECNOLOGIA tECNOLOGIA = db.TECNOLOGIA.Find(id);
            db.TECNOLOGIA.Remove(tECNOLOGIA);
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
