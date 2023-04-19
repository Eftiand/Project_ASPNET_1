using Backend_App.Filters;
using Backend_App.Models.DTO.Product;
using Backend_App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend_App.Controllers
{
    [UseApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        
        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAllAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _productService.GetProductAsync(id));
        }
        
        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            return Ok(await _productService.GetByStatusAsync(status));
        }
        
        [Authorize(Roles = "admin, productOwner")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductRequest productRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            return Created("",await _productService.CreateAsync(productRequest));
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            await _productService.DeleteAsync(id);
            return Ok();
        }
        [HttpGet("search/{search}")]
        public async Task<IActionResult> Search(string search)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            
            var result = await _productService.SearchAsync(search);
            
            return Ok(result);
        }

    }
}
