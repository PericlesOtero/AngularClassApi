using AngularClassApi.Models;
using AngularClassApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AngularClassApi.Controllers
{
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Route("v1/product/")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(_productRepository.GetAll());
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [Route("v1/product/{id:int}")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
            try
            {
                return new ObjectResult(_productRepository.GetById(id));
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [Route("v1/product/")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] ProductModel data)
        {
            if (!ModelState.IsValid)
                BadRequest(ModelState);

            try
            {
                _productRepository.Create(data);

                var product = _productRepository.Last();

                return new ObjectResult(product);
            }
            catch (System.Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }


        [Route("v1/product/")]
        [HttpPut]
        [AllowAnonymous]
        public IActionResult Put([FromBody] ProductModel data)
        {
            if (!ModelState.IsValid)
                BadRequest(ModelState);

            try
            {
                _productRepository.Update(data);

                var product = _productRepository.GetById(data.Id);

                return new ObjectResult(product);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [Route("v1/product/{id:int}")]
        [HttpDelete]
        [AllowAnonymous]
        public IActionResult Delete(int id)
        {
            try
            {
                _productRepository.Delete(id);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
