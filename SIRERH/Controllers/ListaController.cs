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
    public class ListaController : Controller
    {
        private Proyecto_P5Entities db = new Proyecto_P5Entities();


        // GET: USUARIOs
        public ActionResult Index()
        {
            var usuarios = db.USUARIO.ToList();
            var tecnologias = db.TECNOLOGIA.ToList();
            var model = new ListaViewModel()
            {
                ListaUsuarios = usuarios,
                ListaTecnologias = tecnologias
            };

            return View(model);
            
        }

    }

}

