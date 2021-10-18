using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridgeApi.Data.Models;
using ShopBridgeApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ShopBridgeApi.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    //public class ProductssController : ControllerBase
    //{
    //}

    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productRepository;
        public ProductsController(IProductService productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            try
            {
                var products = await _productRepository.GetAll();
                return Ok(products);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> Get(int id)
        {
            try
            {
            var product = await _productRepository.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
            }
              catch(Exception ex)
            {
               throw ex;
            }
            
        }

        // POST api/<ProductsController>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] Product product)
        {

            try
            {

                int existingProductCount = await _productRepository.GetProdCountByName(product.Name);
                if (existingProductCount == 0)
                {
                    await _productRepository.Add(product);
                    return CreatedAtAction(nameof(Get), new { id = product.ProductId }, product);
                }
                else
                {
                    // here is the code to get to know the Username is already exist  in the database
                    return StatusCode(409, $"Product '{product.Name}' already exists.");
                }
            }

            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Product prod)
        {
        
            try
            {
            var product = await _productRepository.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productRepository.Update(id, prod);
            return Ok();
            }
            
              catch(Exception ex)
            {
               throw ex;
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
          try
            {
            var product = await _productRepository.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productRepository.Delete(id);

            return Ok();
            }
        }
          catch(Exception ex)
            {
               throw ex;
            }
        
    }
}




