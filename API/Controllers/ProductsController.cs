using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        // (2) in order to use dependency injection, we create a private field inside our class
        // then assign that field to the 'context' that we added in our constructor
        // __________ common practice to use underscore for a private readonly field (_context)

        private readonly StoreContext _context;

        // (1) use DEPENDENCY INJECTION to use store context inside here
        // so we can get access to the 'Products' table in the database
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        // (3) creating endpoint and specify the httpmethod that we'll be using
        [HttpGet] // api/products
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();

        }

        [HttpGet("{id}")] // api/products/{id}
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        
    }
}