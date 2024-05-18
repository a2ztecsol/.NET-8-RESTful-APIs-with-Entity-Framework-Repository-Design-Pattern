using DotNetWebAPI.Models.Entites;
using DotNetWebAPI.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IDataRepository<Product> dataRepository;
        public ProductsController(IDataRepository<Product> dataRepository)
        {
            this.dataRepository = dataRepository;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(dataRepository.GetAll());
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}", Name="Get")]
        public IActionResult Get(int id)
        {
            Product product = dataRepository.GetById(id);
            if(product == null)
            {
                return NotFound("Product not found");
            }
            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if(product == null)
            {
                return BadRequest("Product is empty");
            }
            dataRepository.Add(product);
            return CreatedAtRoute(
                        "Get",
                        new { id = product.Id },
                        product
                    );
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            Product dbProduct = dataRepository.GetById(id);
            if(dbProduct == null)
            {
                return NotFound("Product not found");
            }
            if (product == null)
            {
                return BadRequest("Product is empty");
            }
            dataRepository.Update(dbProduct,product);
            return Ok(dbProduct);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product dbProduct = dataRepository.GetById(id);
            if (dbProduct == null)
            {
                return NotFound("Product not found");
            }
            dataRepository.Delete(dbProduct);
            return NoContent();
        }
    }
}
