using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business.Models;

namespace Business.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly PaymentDbContext _context;

        public ProductCategoriesController(PaymentDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategorie>>> GetProductCategorie()
        {
            return await _context.ProductCategorie.ToListAsync();
        }

        // GET: api/ProductCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategorie>> GetProductCategorie(Guid id)
        {
            var productCategorie = await _context.ProductCategorie.FindAsync(id);

            if (productCategorie == null)
            {
                return NotFound();
            }

            return productCategorie;
        }

        // PUT: api/ProductCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCategorie(Guid id, ProductCategorie productCategorie)
        {
            if (id != productCategorie.ID)
            {
                return BadRequest();
            }

            _context.Entry(productCategorie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCategorieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductCategories
        [HttpPost]
        public async Task<ActionResult<ProductCategorie>> PostProductCategorie(ProductCategorie productCategorie)
        {
            _context.ProductCategorie.Add(productCategorie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductCategorie", new { id = productCategorie.ID }, productCategorie);
        }

        // DELETE: api/ProductCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductCategorie>> DeleteProductCategorie(Guid id)
        {
            var productCategorie = await _context.ProductCategorie.FindAsync(id);
            if (productCategorie == null)
            {
                return NotFound();
            }

            _context.ProductCategorie.Remove(productCategorie);
            await _context.SaveChangesAsync();

            return productCategorie;
        }

        private bool ProductCategorieExists(Guid id)
        {
            return _context.ProductCategorie.Any(e => e.ID == id);
        }
    }
}
