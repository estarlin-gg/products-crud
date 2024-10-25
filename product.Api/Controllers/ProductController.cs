using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using product_crud.Domain.Context;
using product_crud.Domain.Entities;

namespace product.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(ProductsContext context) : ControllerBase
    {
        private readonly ProductsContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductos()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducto(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProducto(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducto), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Product producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Products.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Products.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

