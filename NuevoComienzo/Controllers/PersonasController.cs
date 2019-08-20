using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuevoComienzo.Data;
using NuevoComienzo.Models;

namespace NuevoComienzo.Controllers
{
    public class PersonasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Persona.Include(p => p.Anotacion).Include(p => p.Direccion).Include(p => p.Identificador).Include(p => p.TipoPersona);


            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(Guid? id)
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
                .FirstOrDefaultAsync(m => m.PersonaId == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            ViewData["AnotacionId"] = new SelectList(_context.Set<Anotacion>(), "AnotacionId", "AnotacionId");
            ViewData["DireccionId"] = new SelectList(_context.Set<Direccion>(), "DireccionId", "DireccionId");
            ViewData["IdentificadorId"] = new SelectList(_context.Set<Identificador>(), "IdentificadorId", "IdentificadorId");
            ViewData["TipoPersonaId"] = new SelectList(_context.Set<TipoPersona>(), "TipoPersonaId", "DescTipoPersona");
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonaId,TipoPersonaId,IdentificadorId,DireccionId,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Sexo,FechaNacimiento,AnotacionId,Correo,Telefono")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                persona.PersonaId = Guid.NewGuid();
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnotacionId"] = new SelectList(_context.Set<Anotacion>(), "AnotacionId", "AnotacionId", persona.AnotacionId);
            ViewData["DireccionId"] = new SelectList(_context.Set<Direccion>(), "DireccionId", "DireccionId", persona.DireccionId);
            ViewData["IdentificadorId"] = new SelectList(_context.Set<Identificador>(), "IdentificadorId", "IdentificadorId", persona.IdentificadorId);
            ViewData["TipoPersonaId"] = new SelectList(_context.Set<TipoPersona>(), "TipoPersonaId", "TipoPersonaId", persona.TipoPersonaId);
            return View(persona);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Persona.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            ViewData["AnotacionId"] = new SelectList(_context.Set<Anotacion>(), "AnotacionId", "AnotacionId", persona.AnotacionId);
            ViewData["DireccionId"] = new SelectList(_context.Set<Direccion>(), "DireccionId", "DireccionId", persona.DireccionId);
            ViewData["IdentificadorId"] = new SelectList(_context.Set<Identificador>(), "IdentificadorId", "IdentificadorId", persona.IdentificadorId);
            ViewData["TipoPersonaId"] = new SelectList(_context.Set<TipoPersona>(), "TipoPersonaId", "TipoPersonaId", persona.TipoPersonaId);
            return View(persona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PersonaId,TipoPersonaId,IdentificadorId,DireccionId,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Sexo,FechaNacimiento,AnotacionId,Correo,Telefono")] Persona persona)
        {
            if (id != persona.PersonaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
            ViewData["AnotacionId"] = new SelectList(_context.Set<Anotacion>(), "AnotacionId", "AnotacionId", persona.AnotacionId);
            ViewData["DireccionId"] = new SelectList(_context.Set<Direccion>(), "DireccionId", "DireccionId", persona.DireccionId);
            ViewData["IdentificadorId"] = new SelectList(_context.Set<Identificador>(), "IdentificadorId", "IdentificadorId", persona.IdentificadorId);
            ViewData["TipoPersonaId"] = new SelectList(_context.Set<TipoPersona>(), "TipoPersonaId", "TipoPersonaId", persona.TipoPersonaId);
            return View(persona);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
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
                .FirstOrDefaultAsync(m => m.PersonaId == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var persona = await _context.Persona.FindAsync(id);
            _context.Persona.Remove(persona);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(Guid id)
        {
            return _context.Persona.Any(e => e.PersonaId == id);
        }
    }
}
