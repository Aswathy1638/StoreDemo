using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreDemo.Data;
using StoreDemo.Models;
using System;

namespace StoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreDemoContext appDbContext;

        public ProductsController(StoreDemoContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get(int categoryId)
        {
            var products = await appDbContext.Products
                .Where(x => x.CategoryId == categoryId)
                .Include(x => x.size)
                .Include(x => x.colors).ToListAsync();
            return products;
        }
    }
}
