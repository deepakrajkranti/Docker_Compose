using Learning.AppContext;
using Learning.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationContext _applicationContext;
        public ProductController(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
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

            // Assuming you have a method to save the product and return the created product
             _applicationContext.Products.AddAsync(product); // Replace with your actual method
            await _applicationContext.SaveChangesAsync();


            return Ok(product);
        }

    }
}
