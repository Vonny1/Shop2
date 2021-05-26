using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop2.Models;
using Microsoft.EntityFrameworkCore;

namespace Shop2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        databaseContext db = new databaseContext();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await db.Products.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            Product product = await db.Products.FirstOrDefaultAsync(x=>x.Id==id);
            return product;
        }
        [HttpPost]
        public async Task<ActionResult<Product>> Post (Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return Ok(product);
        }
        [HttpPut]
        public async Task<ActionResult<Product>> Put (Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            if (!db.Products.Any(x=>x.Id==product.Id))
            {
                return NotFound();
            }
            db.Update(product);
            await db.SaveChangesAsync();
            return Ok(product);
        }
        [HttpDelete]
        public async Task<ActionResult<Product>> Delete (Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return Ok(product);
        }

    }
}
