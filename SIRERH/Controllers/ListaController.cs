using SIRERH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIRERH.Controllers
{
    public class ListaController : Controller
    {


       
        private Proyecto_P5Entities db = new Proyecto_P5Entities();
        

        // GET: Lista
        public ActionResult Index()
        {

            var model = new ListaModel();

            model.tECNOLOGIA = db.TECNOLOGIA.ToList();
            model.uSUARIO = db.USUARIO.ToList();
            model.vACANTE = db.VACANTE.ToList();
            var o = db.VACANTE.ToList() ;
            var e = from VACANTE in o select new {  VACANTE.PUESTO };
            ViewBag.Puesto =  e;
            return View(model.vACANTE.ToList());
        }

        // GET: Lista/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Lista/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lista/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Lista/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Lista/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Lista/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lista/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
