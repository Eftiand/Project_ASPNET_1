using Backend_App.Filters;
using Backend_App.Models.DTO.Authentication;
using Backend_App.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend_App.Controllers
{
    [UseApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;


        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] RegistrationForm registrationForm)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _authService.SignUpAsync(registrationForm);
           
            if(!result)
                return BadRequest();
           
            return Created("", null);
        }
        
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] LoginForm loginForm)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var result = await _authService.SignInAsync(loginForm);
            
            
            if (string.IsNullOrEmpty(result))
                return Unauthorized();
            
            return Ok(result);
        }
        
        [HttpGet("Users/GetAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _authService.GetAllAsync());
        }
        
        [HttpGet("SignOut")]
        public async Task<IActionResult> SignOut()
        {
            await _authService.SignOutAsync();
            return Ok();
        }
        
        
    }
}
