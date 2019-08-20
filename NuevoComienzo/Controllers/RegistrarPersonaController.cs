using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuevoComienzo.Data;
using NuevoComienzo.Models;

namespace NuevoComienzo.Controllers
{
    public class RegistrarPersonaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistrarPersonaController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: RegistrarPersona
        public async Task<IActionResult> Index()
        {
            var persona = _context.Persona.Include(p => p.Direccion);
            return View(await persona.ToListAsync());
        }

        // GET: RegistrarPersona/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistrarPersona/Create
        public ActionResult Create()
        {
            var sexo = new SelectList(new List<string> { "H", "M"});
            ViewData["TipoIdentificadorId"] = new SelectList(_context.Set<TipoIdentificador>(), "TipoIdentificadorId", "DescTipoIdentificador");
            ViewData["TipoPersonaId"] = new SelectList(_context.TipoPersona, "TipoPersonaId", "DescTipoPersona");
            ViewData["DistritoId"] = new SelectList(_context.Set<Distrito>(), "DistritoId", "Nombre");
            ViewData["Sexo"] = sexo;
            RegistrarPersonaVM vm = new RegistrarPersonaVM();
            return View();
        }

        // POST: RegistrarPersona/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,DescDireccion,Medicamentos,DistritoId,Alergias,DiagnosticoAprendizaje,DiagnosticoPsicologico,ObservacionesSupervisor,IdentificadorId,TipoIdentificadorId,Correo,Telefono,TipoPersonaId,FechaNacimiento")]RegistrarPersonaVM vm)
        {
            try
            {
                var direccion = new Direccion
                {
                    DescDireccion = vm.DescDireccion,
                    DistritoId = vm.DistritoId,
                };

                var anotacion = new Anotacion
                {
                    Medicamentos = vm.Medicamentos,
                    Alergias = vm.Alergias,
                    DiagnosticoAprendizaje = vm.DiagnosticoAprendizaje,
                    DiagnosticoPsicologico = vm.DiagnosticoPsicologico,
                    ObservacionesSupervisor = vm.ObservacionesSupervisor
                };

                var identificador = new Identificador
                {
                    IdentificadorId = vm.IdentificadorId,
                    TipoIdentificadorId = vm.TipoIdentificadorId
                };

                _context.Direccion.Add(direccion);
                _context.Anotacion.Add(anotacion);
                _context.Identificador.Add(identificador);

                var persona = new Persona
                {
                    PrimerNombre = vm.PrimerNombre,
                    SegundoNombre = vm.SegundoNombre,
                    PrimerApellido = vm.PrimerApellido,
                    SegundoApellido = vm.SegundoApellido,
                    Sexo = vm.Sexo,
                    TipoPersonaId = vm.TipoPersonaId,
                    IdentificadorId = identificador.IdentificadorId,
                    AnotacionId = anotacion.AnotacionId,
                    Correo = vm.Correo,
                    Telefono = vm.Telefono,
                    FechaNacimiento = vm.FechaNacimiento,
                    DireccionId = direccion.DireccionId

                };
                _context.Persona.Add(persona);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e;
                return View();
            }
        }

        // GET: RegistrarPersona/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistrarPersona/Edit/5
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

        // GET: RegistrarPersona/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistrarPersona/Delete/5
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