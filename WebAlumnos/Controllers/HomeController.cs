using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAlumnos.Models;

namespace WebAlumnos.Controllers
{
    public class HomeController : Controller
    {



        // GET: Home
        public ActionResult Index()
        {
            var db = new CursosEntities();
           
                return View(db.Alumnos.ToList());

            
        }

        public ActionResult Alta()
        {
            return View(new Alumnos());
        }

        [HttpPost]
        public ActionResult Alta(Alumnos model)
        {
            if (ModelState.IsValid)
            {
                using (var db=new CursosEntities())
                {
                    db.Alumnos.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

    }
}