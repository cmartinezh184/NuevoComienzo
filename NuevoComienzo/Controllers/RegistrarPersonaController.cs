﻿using System;
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
                var persona = _context.Persona.Include(p => p.TipoPersona);
                return View(await persona.ToListAsync());
        }

        // GET: RegistrarPersona/Details/5
        public async Task<IActionResult> Details(int? id)
        {
                if (id == null)
                {
                    return NotFound();
                }

                var persona = await _context.Persona
                    .Include(p => p.Anotacion)
                    .Include(p => p.Direccion)
                    .Include(p => p.Identificador)
                    .Include(p => p.TipoPersona)
                    .Include(p => p.Identificador.TipoIdentificador)
                    .Include(p => p.Direccion.Distrito)
                    .Include(p => p.Direccion.Distrito.Canton)
                    .Include(p => p.Direccion.Distrito.Canton.Provincia)


                    .FirstOrDefaultAsync(m => m.PersonaId == id);
                if (persona == null)
                {
                    return NotFound();
                }

                ViewData["TipoIdentificadorId"] = new SelectList(_context.Set<TipoIdentificador>(), "TipoIdentificadorId", "DescTipoIdentificador");
                ViewData["TipoPersonaId"] = new SelectList(_context.TipoPersona, "TipoPersonaId", "DescTipoPersona");
                ViewData["DistritoId"] = new SelectList(_context.Set<Distrito>(), "DistritoId", "Nombre");
                ViewData["CantonId"] = new SelectList(_context.Set<Distrito>(), "CantonId", "Nombre");
                ViewData["ProvinciaId"] = new SelectList(_context.Set<Distrito>(), "ProvinciaId", "Nombre");
                ViewData["DireccionId"] = new SelectList(_context.Set<Distrito>(), "DireccionId", "DescDireccion");


                return View(persona);
        }

        // GET: RegistrarPersona/Create
        public ActionResult Create()
        {
            ViewData["TipoIdentificadorId"] = new SelectList(_context.Set<TipoIdentificador>(), "TipoIdentificadorId", "DescTipoIdentificador");
            ViewData["TipoPersonaId"] = new SelectList(_context.TipoPersona, "TipoPersonaId", "DescTipoPersona");
            ViewData["DistritoId"] = new SelectList(_context.Set<Distrito>(), "DistritoId", "Nombre");
            var vm = new RegistrarPersonaVM();
            return View();
        }

        // POST: RegistrarPersona/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Sexo,DescDireccion,Medicamentos,DistritoId,Alergias,DiagnosticoAprendizaje,DiagnosticoPsicologico,ObservacionesSupervisor,IdentificadorId,TipoIdentificadorId,Correo,Telefono,TipoPersonaId,FechaNacimiento")]RegistrarPersonaVM vm)
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Persona.FindAsync(id);
            var identificador = await _context.Identificador.FindAsync(persona.IdentificadorId);
            var anotacion = await _context.Anotacion.FindAsync(persona.AnotacionId);
            var direccion = await _context.Direccion.FindAsync(persona.DireccionId);

            var vm = new RegistrarPersonaVM
            {
                IdentificadorId = persona.IdentificadorId,
                TipoIdentificadorId = identificador.TipoIdentificadorId,
                PrimerNombre = persona.PrimerNombre,
                SegundoNombre = persona.SegundoNombre,
                PrimerApellido = persona.PrimerApellido,
                SegundoApellido = persona.SegundoApellido,
                Sexo = persona.Sexo,
                TipoPersonaId = persona.TipoPersonaId,
                Correo = persona.Correo,
                Telefono = persona.Telefono,
                FechaNacimiento = persona.FechaNacimiento,
                Medicamentos = anotacion.Medicamentos,
                Alergias = anotacion.Alergias,
                DiagnosticoAprendizaje = anotacion.DiagnosticoAprendizaje,
                DiagnosticoPsicologico = anotacion.DiagnosticoPsicologico,
                DescDireccion = direccion.DescDireccion,
                DistritoId = direccion.DistritoId,
                ObservacionesSupervisor = anotacion.ObservacionesSupervisor
            };

            if (persona == null)
            {
                return NotFound();
            }
            ViewData["TipoIdentificadorId"] = new SelectList(_context.Set<TipoIdentificador>(), "TipoIdentificadorId", "DescTipoIdentificador");
            ViewData["TipoPersonaId"] = new SelectList(_context.TipoPersona, "TipoPersonaId", "DescTipoPersona");
            ViewData["DistritoId"] = new SelectList(_context.Set<Distrito>(), "DistritoId", "Nombre");
            return View(vm);
        }

        // POST: RegistrarPersona/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Sexo,DescDireccion,Medicamentos,DistritoId,Alergias,DiagnosticoAprendizaje,DiagnosticoPsicologico,ObservacionesSupervisor,IdentificadorId,TipoIdentificadorId,Correo,Telefono,TipoPersonaId,FechaNacimiento")]RegistrarPersonaVM vm)
        {
            var persona = await _context.Persona.FindAsync(id);
            var identificador = await _context.Identificador.FindAsync(vm.IdentificadorId);
            var anotacion = await _context.Anotacion.FindAsync(persona.AnotacionId);
            var direccion = await _context.Direccion.FindAsync(persona.DireccionId);

            if (id != persona.PersonaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    direccion.DescDireccion = vm.DescDireccion;
                    direccion.DistritoId = vm.DistritoId;

                    _context.Update(direccion);

                    anotacion.Medicamentos = vm.Medicamentos;
                    anotacion.Alergias = vm.Alergias;
                    anotacion.DiagnosticoAprendizaje = vm.DiagnosticoAprendizaje;
                    anotacion.DiagnosticoPsicologico = vm.DiagnosticoPsicologico;
                    anotacion.ObservacionesSupervisor = vm.ObservacionesSupervisor;

                    _context.Update(anotacion);

                    identificador.IdentificadorId = vm.IdentificadorId;
                    identificador.TipoIdentificadorId = vm.TipoIdentificadorId;

                    persona.PrimerNombre = vm.PrimerNombre;
                    persona.SegundoNombre = vm.SegundoNombre;
                    persona.PrimerApellido = vm.PrimerApellido;
                    persona.SegundoApellido = vm.SegundoApellido;
                    persona.Sexo = vm.Sexo;
                    persona.TipoPersonaId = vm.TipoPersonaId;
                    persona.IdentificadorId = identificador.IdentificadorId;
                    persona.AnotacionId = anotacion.AnotacionId;
                    persona.Correo = vm.Correo;
                    persona.Telefono = vm.Telefono;
                    persona.FechaNacimiento = vm.FechaNacimiento;
                    persona.DireccionId = direccion.DireccionId;

                    _context.Update(persona);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.PersonaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoIdentificadorId"] = new SelectList(_context.Set<TipoIdentificador>(), "TipoIdentificadorId", "DescTipoIdentificador");
            ViewData["TipoPersonaId"] = new SelectList(_context.TipoPersona, "TipoPersonaId", "DescTipoPersona");
            ViewData["DistritoId"] = new SelectList(_context.Set<Distrito>(), "DistritoId", "Nombre");
            return View(persona);
        }

        // GET: RegistrarPersona/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Persona
                .Include(p => p.Anotacion)
                .Include(p => p.Direccion)
                .Include(p => p.Identificador)
                .Include(p => p.TipoPersona)
                .Include(p => p.Identificador.TipoIdentificador)
                .Include(p => p.Direccion.Distrito)
                .Include(p => p.Direccion.Distrito.Canton)
                .Include(p => p.Direccion.Distrito.Canton.Provincia)


                .FirstOrDefaultAsync(m => m.PersonaId == id);
            if (persona == null)
            {
                return NotFound();
            }

            ViewData["TipoIdentificadorId"] = new SelectList(_context.Set<TipoIdentificador>(), "TipoIdentificadorId", "DescTipoIdentificador");
            ViewData["TipoPersonaId"] = new SelectList(_context.TipoPersona, "TipoPersonaId", "DescTipoPersona");
            ViewData["DistritoId"] = new SelectList(_context.Set<Distrito>(), "DistritoId", "Nombre");
            ViewData["CantonId"] = new SelectList(_context.Set<Distrito>(), "CantonId", "Nombre");
            ViewData["ProvinciaId"] = new SelectList(_context.Set<Distrito>(), "ProvinciaId", "Nombre");
            ViewData["DireccionId"] = new SelectList(_context.Set<Distrito>(), "DireccionId", "DescDireccion");


            return View(persona);
        }

        // POST: RegistrarPersona/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var persona = await _context.Persona.FindAsync(id);
            var identificador = await _context.Identificador.FindAsync(persona.IdentificadorId);
            var anotacion = await _context.Anotacion.FindAsync(persona.AnotacionId);
            var direccion = await _context.Direccion.FindAsync(persona.DireccionId);
            try
            {
                if (id != persona.PersonaId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Remove(direccion);
                        _context.Remove(anotacion);
                        _context.Remove(identificador);
                        _context.Remove(persona);

                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PersonaExists(persona.PersonaId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                ViewData["TipoIdentificadorId"] = new SelectList(_context.Set<TipoIdentificador>(), "TipoIdentificadorId", "DescTipoIdentificador");
                ViewData["TipoPersonaId"] = new SelectList(_context.TipoPersona, "TipoPersonaId", "DescTipoPersona");
                ViewData["DistritoId"] = new SelectList(_context.Set<Distrito>(), "DistritoId", "Nombre");
                return RedirectToAction(nameof(Index));
            }catch (Exception e)
            {
                ViewBag.ErrorMessage = e;
                return View();
            }
        }

        private bool PersonaExists(int id)
        {
            return _context.Persona.Any(e => e.PersonaId == id);
        }
    }
}