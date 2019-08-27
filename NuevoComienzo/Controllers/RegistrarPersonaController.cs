using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuevoComienzo.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace NuevoComienzo.Controllers
{

    public class RegistrarPersonaController : Controller
    {
        /// <summary>
        /// Estado e informacion de la sesion del administrador
        /// </summary>
        private readonly SignInManager<IdentityUser> SignInManager;
        private readonly UserManager<IdentityUser> UserManager;

        /// <summary>
        /// Contexto de la base de datos para hacer cambios a las tabnlas
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor del controlador
        /// </summary>
        /// <param name="context">Cpntexto de la base de datos a modificar</param>
        public RegistrarPersonaController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            SignInManager = signInManager;
            UserManager = userManager;
        }

        /// <summary>
        /// Metodo que muestra la vista con las tablas de personas
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            // Verifica si hay una sesion iniciada
            if (SignInManager.IsSignedIn(User))// Si hay sesion iniciada muestra las tablas de personas
            {
                var persona = _context.Persona.Include(p => p.TipoPersona);
                return View(await persona.ToListAsync());
            }
            else// Si no hay sesion iniciada redirecciona a la pagina principal
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// Metodo que muestra toda la informacion de la persona seleccionada en la lista
        /// </summary>
        /// <param name="id">Identificador privado de la persona</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (SignInManager.IsSignedIn(User)) // Si hay una sesion iniciada de administrador
            {
                if (id == null)
                {
                    return NotFound();
                }
                // Obtiene la informacion relacionada a la persona de la base de datos
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

                // Cambia los valores a mostrar de las referencias de la persona por sus descripciones en lugar de su ID
                ViewData["TipoIdentificadorId"] = new SelectList(_context.Set<TipoIdentificador>(), "TipoIdentificadorId", "DescTipoIdentificador");
                ViewData["TipoPersonaId"] = new SelectList(_context.TipoPersona, "TipoPersonaId", "DescTipoPersona");
                ViewData["DistritoId"] = new SelectList(_context.Set<Distrito>(), "DistritoId", "Nombre");
                ViewData["CantonId"] = new SelectList(_context.Set<Distrito>(), "CantonId", "Nombre");
                ViewData["ProvinciaId"] = new SelectList(_context.Set<Distrito>(), "ProvinciaId", "Nombre");
                ViewData["DireccionId"] = new SelectList(_context.Set<Distrito>(), "DireccionId", "DescDireccion");


                return View(persona);
            }
            else // Si no hay sesion iniciada vuelve a la pagina principal
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// Metodo que devuelve la vista para agregar personas a la base de datos
        /// </summary>
        /// <returns>Vista de creacion de personas</returns>
        public ActionResult Create()
        {
            if (SignInManager.IsSignedIn(User)) // Si hay sesion iniciada
            {
                // Cambia los valores de las referencias a otras tablas por sus descripciones
                ViewData["TipoIdentificadorId"] = new SelectList(_context.Set<TipoIdentificador>(), "TipoIdentificadorId", "DescTipoIdentificador");
                ViewData["TipoPersonaId"] = new SelectList(_context.TipoPersona, "TipoPersonaId", "DescTipoPersona");
                ViewData["DistritoId"] = new SelectList(_context.Set<Distrito>(), "DistritoId", "Nombre");

                // Se instancia un View Model
                var vm = new RegistrarPersonaVM();
                return View();
            }
            else // Si no hay sesion iniciada se vuelve a la pagina principal
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// Metodo que obtiene los parametros ingresados en el formulario para 
        /// ingresar una persona a base de datos
        /// </summary>
        /// <param name="vm">View Model para mostrar los campos necesarios para
        /// agregar toda la informacion de la persona</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Sexo,DescDireccion,Medicamentos,DistritoId,Alergias,DiagnosticoAprendizaje,DiagnosticoPsicologico,ObservacionesSupervisor,IdentificadorId,TipoIdentificadorId,Correo,Telefono,TipoPersonaId,FechaNacimiento")]RegistrarPersonaVM vm)
        {
            if (SignInManager.IsSignedIn(User)) // Se verifica si hay sesion iniciada
            {
                try
                {
                    // Se instancia un objeto de tipo Direccion con los valores obtenidos del View Model
                    var direccion = new Direccion
                    {
                        DescDireccion = vm.DescDireccion,
                        DistritoId = vm.DistritoId,
                    };

                    // Se instancia un objeto de tipo Anotacion con los valores obtenidos del View Model
                    var anotacion = new Anotacion
                    {
                        Medicamentos = vm.Medicamentos,
                        Alergias = vm.Alergias,
                        DiagnosticoAprendizaje = vm.DiagnosticoAprendizaje,
                        DiagnosticoPsicologico = vm.DiagnosticoPsicologico,
                        ObservacionesSupervisor = vm.ObservacionesSupervisor
                    };

                    // Se instancia un objeto de tipo Identifiacdor con los valores obtenidos del View Model
                    var identificador = new Identificador
                    {
                        IdentificadorId = vm.IdentificadorId,
                        TipoIdentificadorId = vm.TipoIdentificadorId
                    };

                    // Se agregan objetos con estos valores a la base de datos
                    // Se agregan primero que persona para no incurrir en un error al agregar en base de datos a la persona
                    _context.Direccion.Add(direccion);
                    _context.Anotacion.Add(anotacion);
                    _context.Identificador.Add(identificador);

                    // Se instancia un objeto de tipo Persona con los valores obtenidos del View Model
                    var persona = new Persona
                    {
                        PrimerNombre = vm.PrimerNombre,
                        SegundoNombre = vm.SegundoNombre,
                        PrimerApellido = vm.PrimerApellido,
                        SegundoApellido = vm.SegundoApellido,
                        Sexo = vm.Sexo,
                        TipoPersonaId = vm.TipoPersonaId,
                        IdentificadorId = identificador.IdentificadorId, // Se usa el ID del identificador ya creado como llave foranea para el nuevo objeto de persona en base de datos
                        AnotacionId = anotacion.AnotacionId, // Se usa el ID de la anotacion ya creado como llave foranea para el nuevo objeto de persona en base de datos
                        Correo = vm.Correo,
                        Telefono = vm.Telefono,
                        FechaNacimiento = vm.FechaNacimiento,
                        DireccionId = direccion.DireccionId // Se usa el ID de la direccion ya creado como llave foranea para el nuevo objeto de persona en base de datos

                    };
                    // Se agrega a la persona a base de datos
                    _context.Persona.Add(persona);

                    // Se guardan los cambios en la base de datos
                    await _context.SaveChangesAsync();

                    // Se vuelve a la pagina de tablas de personas
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    // En caso de haber un error, se guarda para ser puesto en pantalla
                    ViewBag.ErrorMessage = e;
                    return View();
                }
            }
            else // Si no hay sesion iniciada se vuelve a la pagina principal
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// Metodo para obtener la informacion de base de datos necesaria para editar a la persona seleccionada
        /// </summary>
        /// <param name="id">Identificador privado de la persona seleccionada</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (SignInManager.IsSignedIn(User)) // Si hay sesion de administrador iniciada
            {
                if (id == null)
                {
                    return NotFound();
                }

                // Se busca a la persona y a todas sus referencias correspondientes en base de datos
                var persona = await _context.Persona.FindAsync(id);
                var identificador = await _context.Identificador.FindAsync(persona.IdentificadorId);
                var anotacion = await _context.Anotacion.FindAsync(persona.AnotacionId);
                var direccion = await _context.Direccion.FindAsync(persona.DireccionId);

                // Se crea un nuevo View Model con los datos obtenidos de la base de datos para exponer en la pagina de edicion
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

                // Cambia los valores de las referencias a otras tablas por sus descripciones
                ViewData["TipoIdentificadorId"] = new SelectList(_context.Set<TipoIdentificador>(), "TipoIdentificadorId", "DescTipoIdentificador");
                ViewData["TipoPersonaId"] = new SelectList(_context.TipoPersona, "TipoPersonaId", "DescTipoPersona");
                ViewData["DistritoId"] = new SelectList(_context.Set<Distrito>(), "DistritoId", "Nombre");
                return View(vm);
            }
            else // Si no hay sesion iniciada se vuelve a la pagina principal
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// Metodo para editar a la persona seleccionada de la tabla del index
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Sexo,DescDireccion,Medicamentos,DistritoId,Alergias,DiagnosticoAprendizaje,DiagnosticoPsicologico,ObservacionesSupervisor,IdentificadorId,TipoIdentificadorId,Correo,Telefono,TipoPersonaId,FechaNacimiento")]RegistrarPersonaVM vm)
        {
            if (SignInManager.IsSignedIn(User)) // Si hay sesion de administrador iniciada
            {
                // Se busca a la persona y a todas las referencias de esta en base de datos
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
                        // Se actualiza el objeto con los nuevos datos actualizados
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

                        await _context.SaveChangesAsync(); // Se salvan los cambios en base de datos
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

                // Cambia los valores de las referencias a otras tablas por sus descripciones
                ViewData["TipoIdentificadorId"] = new SelectList(_context.Set<TipoIdentificador>(), "TipoIdentificadorId", "DescTipoIdentificador");
                ViewData["TipoPersonaId"] = new SelectList(_context.TipoPersona, "TipoPersonaId", "DescTipoPersona");
                ViewData["DistritoId"] = new SelectList(_context.Set<Distrito>(), "DistritoId", "Nombre");
                return View(persona);
            }
            else // Si no hay sesion iniciada se vuelve a la pagina principal
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// Metodo para obtener la informacion de la persona seleccionada de la tabla para ser borrada
        /// </summary>
        /// <param name="id">Identificador privado de la persona seleccionada</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (SignInManager.IsSignedIn(User)) // Si hay sesion de administrador iniciada
            {
                if (id == null)
                {
                    return NotFound();
                }

                // Se obtienen todas las referencias de la persona para mostrar en pantalla
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

                // Cambia los valores de las referencias a otras tablas por sus descripciones
                ViewData["TipoIdentificadorId"] = new SelectList(_context.Set<TipoIdentificador>(), "TipoIdentificadorId", "DescTipoIdentificador");
                ViewData["TipoPersonaId"] = new SelectList(_context.TipoPersona, "TipoPersonaId", "DescTipoPersona");
                ViewData["DistritoId"] = new SelectList(_context.Set<Distrito>(), "DistritoId", "Nombre");
                ViewData["CantonId"] = new SelectList(_context.Set<Distrito>(), "CantonId", "Nombre");
                ViewData["ProvinciaId"] = new SelectList(_context.Set<Distrito>(), "ProvinciaId", "Nombre");
                ViewData["DireccionId"] = new SelectList(_context.Set<Distrito>(), "DireccionId", "DescDireccion");


                return View(persona);
            }
            else // Si no hay sesion iniciada se vuelve a la pagina principal
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// Metodo para borrar a la persona y todos los datos relacionados con esa persona en la base de datos
        /// </summary>
        /// <param name="id">Identificador de la persona a borrar</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (SignInManager.IsSignedIn(User)) // Si hay sesion de administrador iniciada
            {
                // Se busca a la personas y todas sus referencias en base de datos
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
                            // Se borran todos los objetos relacionados con la persona de la base de datos
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

                    // Cambia los valores de las referencias a otras tablas por sus descripciones
                    ViewData["TipoIdentificadorId"] = new SelectList(_context.Set<TipoIdentificador>(), "TipoIdentificadorId", "DescTipoIdentificador");
                    ViewData["TipoPersonaId"] = new SelectList(_context.TipoPersona, "TipoPersonaId", "DescTipoPersona");
                    ViewData["DistritoId"] = new SelectList(_context.Set<Distrito>(), "DistritoId", "Nombre");
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ViewBag.ErrorMessage = e;
                    return View();
                }
            }
            else // Si no hay sesion iniciada se vuelve a la pagina principal
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// Metodo para buscar si la persona existe en base de datos
        /// </summary>
        /// <param name="id">Identificador de la persona a buscar</param>
        /// <returns></returns>
        private bool PersonaExists(int id)
        {
            if (SignInManager.IsSignedIn(User)) // Si hay sesion de administrador iniciada
            {
                // Se busca a la persona y se devuelve el resultado
                return _context.Persona.Any(e => e.PersonaId == id);
            }
            else
            {
                // Si no hay sesion de administrador iniciada no se hace la busqueda por seguridad
                return false;
            }
        }
    }
}