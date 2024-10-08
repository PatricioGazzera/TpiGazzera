using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TpiGazzera.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<ProductDto>> GetAll()
        {
            return _productService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> Get([FromRoute] int id) 
        { 
            try
            {
                return _productService.GetById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public ActionResult<List<Product>> GetAllFullData(IProductService productService)
        {
            return _productService.GetAllFullData();   
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductCreateRequest productCreateRequest) 
        {
            var newObj = _productService.Create(productCreateRequest);
            return CreatedAtAction(nameof(Get), new { id = newObj.Id }, newObj);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ProductUpdateRequest productUpdateRequest)
        {
            try
            {
                _productService.Update(id, productUpdateRequest);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _productService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
