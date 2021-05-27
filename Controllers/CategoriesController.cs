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
    public class CategoriesController : ControllerBase
    {
        databaseContext db = new databaseContext();
        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            return await db.Categories.ToListAsync();
        }

    }
}
