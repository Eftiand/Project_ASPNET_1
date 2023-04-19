using Backend_App.Filters;
using Backend_App.Models.DTO.Product;
using Backend_App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend_App.Controllers
{
    [UseApiKey]
    [Authorize(Roles = "admin, productOwner")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ProductService _productService;


        public AdminController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("CheckUser")]
        public IActionResult CheckUser()
        {
            return Ok();
        }
        
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductRequest productRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            return Created("",await _productService.CreateAsync(productRequest));
        }
    }
    
}
