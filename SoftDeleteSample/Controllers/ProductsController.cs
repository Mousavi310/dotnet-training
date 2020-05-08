using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SoftDeleteSample.Controllers
{
    public class ProductsController : Controller
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [Route("api/products")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Created($"api/products/{product.Id}", product);
        }

        [Route("api/products")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var list = await _context.Products.ToListAsync();
            return Ok(list);
        }

        [Route("api/products/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return NotFound();

            product.IsDeleted = true;

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
