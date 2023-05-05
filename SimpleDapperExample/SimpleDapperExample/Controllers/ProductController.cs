using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleDapperExample.Entities;
using SimpleDapperExample.Repositories;

namespace SimpleDapperExample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var result = _productRepository.GetAll();
            return Ok(result);
        }    
        [HttpGet]
        public IActionResult GetProductById([FromQuery] int id)
        {
            var result = _productRepository.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            _productRepository.Insert(product);
            return Ok("Added successfully");
        }  
        [HttpPost]
        public IActionResult AddProductWithSp([FromBody] Product product)
        {
            _productRepository.InsertWithSP(product);
            return Ok("Added successfully");
        }  
        [HttpPut]
        public IActionResult EditProduct([FromBody] Product product)
        {
            _productRepository.Update(product);
            return Ok("Editted successfully");
        }  
        [HttpDelete]
        public IActionResult RemoveProduct([FromQuery] int id)
        {
            _productRepository.Delete(id);
            return Ok("Removed successfully");
        }


    }
}
