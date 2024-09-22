using Microsoft.AspNetCore.Mvc;
using SegundoModulo.Models;
using SegundoModulo.Data; // importar el namespace donde está tu DbContext
using System.Linq;

namespace SegundoModulo.Controllers
{
    public class PruebaController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor con inyección de dependencia para DbContext
        public PruebaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método para agregar valores a la base de datos (esto sería solo para pruebas)
       /* public void AgregarValoresObjeto()
        {
            var prueba = new Prueba { Nombre = "Luis", Descripcion = "Descripcion" };
            _context.Pruebas.Add(prueba);
            _context.SaveChanges(); // Guarda los cambios en la base de datos
        }*/

        /*public IActionResult Index()
        {
            AgregarValoresObjeto(); // Solo para pruebas
            var prueba = _context.Pruebas.FirstOrDefault(); // Obtenemos el primer elemento de la base de datos
            ViewData["datoPrueba"] = prueba;
            return View();
        }*/

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Tabla()
        {
            var listaPruebas = _context.Pruebas.ToList(); // Obtenemos la lista desde la base de datos
            ViewData["lstDatos"] = listaPruebas;
            return View();
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(Prueba model)
        {
            _context.Pruebas.Add(model); // Añadir el nuevo objeto a la base de datos
            _context.SaveChanges(); // Guardar los cambios
            return RedirectToAction("Tabla");
        }

        public IActionResult Editar(int id)
        {
            var pruebaEd = _context.Pruebas.FirstOrDefault(p => p.Id == id); // Buscar objeto por ID
            if (pruebaEd == null)
            {
                return NotFound();
            }
            return View(pruebaEd);
        }

        [HttpPost]
        public IActionResult Actualizar(Prueba model)
        {
            var originalPrueba = _context.Pruebas.FirstOrDefault(p => p.Id == model.Id); // Obtener objeto original
            if (originalPrueba != null)
            {
                originalPrueba.Nombre = model.Nombre;
                originalPrueba.Descripcion = model.Descripcion;
                _context.SaveChanges(); // Guardar cambios en la base de datos
            }
            return RedirectToAction("Tabla");
        }

        public IActionResult Eliminar(int id)
        {
            var prueba = _context.Pruebas.FirstOrDefault(p => p.Id == id); // Buscar el objeto por ID
            if (prueba != null)
            {
                _context.Pruebas.Remove(prueba); // Eliminar objeto de la base de datos
                _context.SaveChanges(); // Guardar cambios
            }
            return RedirectToAction("Tabla");
        }

        public IActionResult VistaPrevia(int id)
        {
            var prueba = _context.Pruebas.FirstOrDefault(p => p.Id == id); // Buscar el objeto por ID
            if (prueba == null)
            {
                return NotFound();
            }
            return View(prueba);
        }

        /* -----------------------------------------------------
         * Código anterior comentado (uso de listas estáticas)
         ------------------------------------------------------*/

        /*
        private Prueba prueba = new Prueba(); // Creación de objetos
        public static List<Prueba> listPrueba = new List<Prueba>(); // Creación de lista

        // Constructor vacío
        public PruebaController()
        {
        }

        public void AgregarValoresObjeto()
        {
            prueba.Id = 1;
            prueba.Nombre = "Luis";
            prueba.Descripcion = "Descripcion";
        }

        public void AgregarValoresLista()
        {
            for (int i = 1; i < 10; i++)
            {
                listPrueba.Add(
                    new Prueba { Id = i, Nombre = "Nombre" + i, Descripcion = "Descripcion" + i }
                );
            }
        }

        public IActionResult Index()
        {
            AgregarValoresObjeto();
            ViewData["datoPrueba"] = prueba;
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Tabla()
        {
            // AgregarValoresLista();
            ViewData["lstDatos"] = listPrueba;
            return View();
        }

        public IActionResult Crear(Prueba model)
        {
            return View();
        }

        public IActionResult Guardar(Prueba model)
        {
            model.Id = listPrueba.Count + 1;
            listPrueba.Add(model);
            return RedirectToAction("Tabla");
        }

        public IActionResult Editar(int id)
        {
            var pruebaEd = listPrueba.FirstOrDefault(p => p.Id == id);
            if (pruebaEd == null)
            {
                return NotFound();
            }
            return View(pruebaEd);
        }

        public IActionResult Actualizar(Prueba model)
        {
            var originalPrueba = listPrueba.FirstOrDefault(p => p.Id == model.Id);

            if (originalPrueba != null)
            {
                originalPrueba.Nombre = model.Nombre;
                originalPrueba.Descripcion = model.Descripcion;
            }
            return RedirectToAction("Tabla");
        }

        public IActionResult Eliminar(int id)
        {
            var prueba = listPrueba.FirstOrDefault(p => p.Id == id);
            if (prueba != null)
            {
                listPrueba.Remove(prueba);
            }
            return RedirectToAction("Tabla");
        }

        public IActionResult VistaPrevia(int id)
        {
            var prueba = listPrueba.FirstOrDefault(p => p.Id == id);
            if (prueba == null)
            {
                return NotFound();
            }
            return View(prueba);
        }
        */
    }
}
