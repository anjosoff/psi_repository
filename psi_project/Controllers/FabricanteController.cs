using psi_project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace psi_project.Controllers
{
    public class FabricanteController : Controller
    {
        private static IList<Fabricante> fabricantes = new List<Fabricante>(){
            new Fabricante() { FabricanteId = 1, Nome = "fabricantes Carros"},
            new Fabricante() { FabricanteId = 2, Nome = "fabricantes Motos"},
            new Fabricante() { FabricanteId = 3, Nome = "fabricantes Impressoras"},
            new Fabricante() { FabricanteId = 4, Nome = "fabricantes Eletro"},
            new Fabricante() { FabricanteId = 5, Nome = "fabricantes Avião"},
            new Fabricante() { FabricanteId = 6, Nome = "fabricantes Notebooks"},
        };
        private EFContext context = new EFContext();

        //public ActionResult Index() => View(fabricantes);

        public ActionResult Create() => View();
        // GET: Fabricante
        public ActionResult Index()
        {
            return View(context.Fabricantes.OrderBy(c=>c.Nome));
        }


        // GET: Create
        /*public ActionResult Create()
        {
            return View();
        }*/
        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            context.Fabricantes.Add(fabricante);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

            // GET: Fabricantes/Edit/5
            [HttpGet]
            public ActionResult Edit(long? id)
        {
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = fabricantes.Where(m => m.FabricanteId == id).First();
            //Fabricante fabricante = context.Fabricantes.Find(id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        // POST: Fabricantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                fabricantes.Remove(
                 fabricantes.Where(c => c.FabricanteId == fabricante.FabricanteId).First());
                fabricantes.Add(fabricante);
                //context.Entry(fabricante).State = EntityState.Modified;
                // context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fabricante);
        }
        // GET: Fabricantes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Fabricante fabricante = context.Fabricantes.Find(id);
            Fabricante fabricante = fabricantes.Where(m => m.FabricanteId == id).First();
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }


        // GET: Fabricantes/Delete/5
        [HttpGet]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Fabricante fabricante = context.Fabricantes.Find(id);
            Fabricante fabricante = fabricantes.Where(m => m.FabricanteId == id).First();
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        // POST: Fabricantes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Fabricante fabricante = fabricantes.Where(c => c.FabricanteId == id).First();
            fabricantes.Remove(fabricante);
            //Fabricante fabricante = context.Fabricantes.Find(id);
            //context.Fabricantes.Remove(fabricante);
            //context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}