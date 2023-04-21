using System.Net.Http.Headers;
using System.Text;
using Inl_uppgift_ASPNET_1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Min_FrontEndApp.Models.DTO;
using Min_FrontEndApp.Models.ViewModels;
using Min_FrontEndApp.Services;
using Newtonsoft.Json;

namespace Min_FrontEndApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _authService;
        private readonly ProductService _productService;

        public AccountController(AuthService authService, ProductService productService)
        {
            _authService = authService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var token = HttpContext.Request.Cookies["accessToken"]?.Trim('"');
            
            if(token == null)
                return RedirectToAction("SignIn");

            return View();
            
            
            
            return RedirectToAction("Index", "Home");
        }
        public IActionResult SignIn()
        {
            var loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel loginViewModel)
        {
            if(!ModelState.IsValid)
                return View(loginViewModel);
           
            var response = await _authService.LoginAsync(loginViewModel);

            if (string.IsNullOrEmpty(response))
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(loginViewModel);
            }

            HttpContext.Response.Cookies.Append("accessToken", response, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTime.Now.AddDays(1)
            });


            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
                return View(registerViewModel);
            
            var response = await _authService.RegisterAsync(registerViewModel);

            if (!response)
            {
                ModelState.AddModelError("", "Invalid register attempt.");
                return View(registerViewModel);
            }
            
            return RedirectToAction("Index", "Account");
        }
        
        [HttpGet("signout")]
        public async Task<IActionResult> SignOut()
        {
            var result = await _authService.LogoutAsync();

            if (!result)
                return BadRequest();
            
            HttpContext.Response.Cookies.Delete("accessToken");
            
            return RedirectToAction("Index", "Home");
            
        }
    }
}
