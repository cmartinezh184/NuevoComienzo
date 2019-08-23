using System;
using Xunit;

namespace PruebasUnitarias
{
    public class UnitTest1
    {

        [Theory]
        [InlineData(1)]
        [InlineData(null)]
        [InlineData(4)]

        public bool ShowDetails(int id)
        {
            if (id == null)
            {
                return false; /* NotFound();*/
            }

            var persona = "informacíón de la persona";

            /*await _context.Persona
            .Include(p => p.Anotacion)
            .Include(p => p.Direccion)
            .Include(p => p.Identificador)
            .Include(p => p.TipoPersona)
            .FirstOrDefaultAsync(m => m.PersonaId == id);*/
            if (persona == null)
            {
                return false; /* NotFound();*/
            }

            return true;
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public bool Create(bool ModelState)
        {

            if (ModelState)
            {
                /*
                persona.PersonaId = Guid.NewGuid();
                _context.Add(persona);
                await _context.SaveChangesAsync();*/
                return true;
            }
            /*
            ViewData["AnotacionId"] = new SelectList(_context.Set<Anotacion>(), "AnotacionId", "AnotacionId", persona.AnotacionId);
            ViewData["DireccionId"] = new SelectList(_context.Set<Direccion>(), "DireccionId", "DireccionId", persona.DireccionId);
            ViewData["IdentificadorId"] = new SelectList(_context.Set<Identificador>(), "IdentificadorId", "IdentificadorId", persona.IdentificadorId);
            ViewData["TipoPersonaId"] = new SelectList(_context.Set<TipoPersona>(), "TipoPersonaId", "TipoPersonaId", persona.TipoPersonaId);*/
            return true; /*View(persona)*/
        }

        [Theory]
        [InlineData(1, 1, true, true)]
        [InlineData(1, null, false, false)]
        [InlineData(null, null, true, false)]
        public bool Edit(int id, int personaid, bool ModelState, bool PersonaExists)
        {
           

            if (id != personaid)
            {
                return false;
            }

            if (ModelState)
            {
                try
                {
                    /*
                    _context.Update(persona);
                    await _context.SaveChangesAsync();*/
                }
                catch (Exception e /*DbUpdateConcurrencyException*/)
                {
                    if (!PersonaExists)
                    {
                        return false;/*NotFound();*/
                    }
                    else
                    {
                        throw;
                    }
                }
                return true;/*RedirectToAction(nameof(Index));*/
            }
            /*
            ViewData["AnotacionId"] = new SelectList(_context.Set<Anotacion>(), "AnotacionId", "AnotacionId", persona.AnotacionId);
            ViewData["DireccionId"] = new SelectList(_context.Set<Direccion>(), "DireccionId", "DireccionId", persona.DireccionId);
            ViewData["IdentificadorId"] = new SelectList(_context.Set<Identificador>(), "IdentificadorId", "IdentificadorId", persona.IdentificadorId);
            ViewData["TipoPersonaId"] = new SelectList(_context.Set<TipoPersona>(), "TipoPersonaId", "TipoPersonaId", persona.TipoPersonaId);*/
            return true;/*View(persona);*/
        }
    }
}
