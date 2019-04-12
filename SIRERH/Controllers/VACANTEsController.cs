using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SIRERH.Models;

namespace SIRERH.Controllers
{
    public class VACANTEsController : Controller
    {
        private Proyecto_P5Entities db = new Proyecto_P5Entities();

        // GET: VACANTEs
        public ActionResult Index()
        {
            return View(db.VACANTE.ToList());
        }

        // GET: VACANTEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VACANTE vACANTE = db.VACANTE.Find(id);
            if (vACANTE == null)
            {
                return HttpNotFound();
            }
            return View(vACANTE);
        }

        // GET: VACANTEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VACANTEs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_VACANTE,PUESTO,HORARIO")] VACANTE vACANTE)
        {
            if (ModelState.IsValid)
            {
                db.VACANTE.Add(vACANTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vACANTE);
        }

        // GET: VACANTEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VACANTE vACANTE = db.VACANTE.Find(id);
            if (vACANTE == null)
            {
                return HttpNotFound();
            }
            return View(vACANTE);
        }

        // POST: VACANTEs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_VACANTE,PUESTO,HORARIO")] VACANTE vACANTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vACANTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vACANTE);
        }

        // GET: VACANTEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VACANTE vACANTE = db.VACANTE.Find(id);
            if (vACANTE == null)
            {
                return HttpNotFound();
            }
            return View(vACANTE);
        }

        // POST: VACANTEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VACANTE vACANTE = db.VACANTE.Find(id);
            db.VACANTE.Remove(vACANTE);
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
