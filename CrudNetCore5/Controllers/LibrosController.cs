using CrudNetCore5.Data;
using CrudNetCore5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCore5.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Libro> listaLibros = _context.Libro;
            return View(listaLibros);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libro.Add(libro);
                _context.SaveChanges();

                TempData["mensaje"] = "Libro creado correctamente";

                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpGet]
        public IActionResult Editar(int? Id)
        {
            if (Id is null || Id == 0) return NotFound();

            Libro libro = _context.Libro.Find(Id);

            if (libro is null) return NotFound();

            return View(libro);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libro.Update(libro);
                _context.SaveChanges();

                TempData["mensaje"] = "Libro actualizado correctamente";

                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpGet]
        public IActionResult Eliminar(int? Id)
        {
            if (Id is null || Id == 0) return NotFound();

            Libro libro = _context.Libro.Find(Id);

            if (libro is null) return NotFound();

            return View(libro);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(int Id)
        {
            Libro libro = _context.Libro.Find(Id);

            if (libro is null) return NotFound();

            _context.Libro.Remove(libro);
            _context.SaveChanges();

            TempData["mensaje"] = "Libro eliminado correctamente";

            return RedirectToAction("Index");
        }
    }
}
