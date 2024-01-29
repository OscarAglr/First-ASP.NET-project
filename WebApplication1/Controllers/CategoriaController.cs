using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly PcStoreContext _context;

        public CategoriaController(PcStoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Categorías.ToListAsync());
        }
    }
}
