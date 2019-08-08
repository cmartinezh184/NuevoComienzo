using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuevoComienzo.Models;

namespace NuevoComienzo.Controllers
{
    public class aController : Controller
    {
        // GET: a
        public ActionResult Index()
        {
            //Modelo de Entity Data Model
            MVCTutorialEntities db = new MVCTutorialEntities();




            Persona per = new Persona();
            per.Direccion = model.Dirección;

            per.PrimerNombre = model.PrimerNombre;
            per.PersonaId = model.PersonaId;


            db.Persona.Add(per);
            db.SaveChanges();







            return View();
        }

        // GET: a/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: a/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: a/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: a/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: a/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: a/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: a/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}