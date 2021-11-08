using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OperaWebSite.Models;
using OperaWebSite.Data;
using System.Data.Entity;

namespace OperaWebSite.Controllers
{
    public class OperaController : Controller
    {
        //dbcontext instance

        private OperaDbContext context = new OperaDbContext();

        // GET: Opera/Opera/Index
        public ActionResult Index()
        {
            //Get all Operas using EF
            var operas = context.Operas.ToList();

            //controller returns "Index" view with opera's list 
            return View("Index", operas);
        }

        //We create 2 methods to insert opera in the DB
                                        
        //GET returns view
        [HttpGet]
        public ActionResult Create()
        {
            // we instance the opera
            Opera opera = new Opera();

            //it returns the viwew "create" with the object opera
            return View("Create", opera);
        }

        //Post to insert new opera in the DB
        //cuando el usuario en la vista Create hace click en enviar
        //Opera/Create -->POST
        [HttpPost]
        public ActionResult Create(Opera opera)
        {
            if (ModelState.IsValid)
            {
                context.Operas.Add(opera);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", opera);
        }

        //GET
        // Opera/Detail/id
        // Opera/Detail/2
        [HttpGet]//optional 
        public ActionResult Detail(int id)
        {
            Opera opera = context.Operas.Find(id);

            if (opera != null)
            {
                return View("Detail", opera);
            }
            else
            {
                return HttpNotFound();
            }
        }

        //GET /Opera/Delete/Id
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Opera opera = context.Operas.Find(id);

            if (opera != null)
            {
                return View("Delete", opera);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // /Opera/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Opera opera = context.Operas.Find(id);

            context.Operas.Remove(opera);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Opera opera = context.Operas.Find(id);
            if (opera != null)
            {
                return View("Edit", opera);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Edit(Opera opera)
        {
            if (ModelState.IsValid)
            {
                context.Entry(opera).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", opera);
        }
    }
}
