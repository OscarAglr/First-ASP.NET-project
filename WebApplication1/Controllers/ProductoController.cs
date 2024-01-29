using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class ProductoController : Controller
    {
        private readonly PcStoreContext _context;

        public ProductoController(PcStoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = _context.Productos.Include(c => c.IdCategoríaNavigation);
            return View(await products.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["Categorías"] = new SelectList(_context.Categorías, "IdCategoría", "NombreCategoría");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var producto = new Producto()
                {
                    NombreProducto = model.NombreProducto,
                    IdCategoría = model.IdCategoria,
                    Precio = model.Precio,
                    Stock = model.Stock
                };
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Categorías"] = new SelectList(_context.Categorías, "IdCategoría", "NombreCategoría", model.IdCategoria);
            return View(model);
        }
    }
}
