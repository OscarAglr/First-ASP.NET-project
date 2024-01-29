using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiProductoController : ControllerBase
    {
        private readonly PcStoreContext _context;

        public ApiProductoController(PcStoreContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> Get()
            => await _context.Productos.ToListAsync();
    }
}
