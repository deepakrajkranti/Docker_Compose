using Learning.AppContext;
using Learning.Cache;
using Learning.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationContext _applicationContext;
        private readonly IDistributedCache _distributedCache;
        public ProductController(ApplicationContext applicationContext, IDistributedCache distributedCache)
        {
            _applicationContext = applicationContext;
            _distributedCache = distributedCache;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null");
            }

            try
            {    // Assuming you have a method to save the product and return the created product
                _applicationContext.Products?.AddAsync(product); // Replace with your actual method
                await _applicationContext.SaveChangesAsync();


                return StatusCode(StatusCodes.Status201Created, product);

            }
              catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id )
        {
            if(id == 0)
            {
                return BadRequest("Id cannot be 0");
            }
            var cached = await _distributedCache.GetRecordAsync<Product>(id.ToString());
            if(cached != null) { 
                 return Ok(cached);
            }
            var products = await _applicationContext.Products.Where(p => p.Id == id).AsNoTracking().FirstOrDefaultAsync();
            await _distributedCache.SetRecordAsync(id.ToString(), products);

            return Ok(products);
        }

    }
}
