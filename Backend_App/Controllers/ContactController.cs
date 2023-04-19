using Backend_App.Filters;
using Backend_App.Models.DTO.Contact;
using Backend_App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend_App.Controllers
{
    [UseApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactService _contactService;
        
        public ContactController(ContactService contactService)
        {
            _contactService = contactService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContactRequest contactRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _contactService.CreateAsync(contactRequest);
            return Created("", null);
        }
    }
}
