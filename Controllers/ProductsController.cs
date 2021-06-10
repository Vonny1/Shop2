using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace Shop2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        databaseContext db = new databaseContext();
        [HttpGet("get/all")]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await db.Products.Include("Category").ToListAsync();
        }
        [HttpGet("get/id/{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            Product product = await db.Products.FirstOrDefaultAsync(x=>x.Id==id);
            return product;
        }
        [HttpPost("post")]
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
        [HttpPut("put")]
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
        [HttpDelete("delete")]
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
        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult<int>> Deleteid (int id)
        {
            Product product = await db.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return BadRequest();
            }
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return Ok(product);
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetCount()
        {
            return await db.Products.CountAsync();
        }

        [HttpGet("get/page/{page}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetPage(int page)
        {
            int max = page*12;
            int min = max - 11;
            return await db.Products.Include("Category").
                Where(x=>x.Id>=min && x.Id<=max).ToListAsync();
        }

    }
}
