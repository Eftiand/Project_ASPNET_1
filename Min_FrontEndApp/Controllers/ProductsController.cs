using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Min_FrontEndApp.Models.DTO;
using Min_FrontEndApp.Models.ViewModels;
using Min_FrontEndApp.Services;

namespace Min_FrontEndApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _apiService;

        public ProductsController(ProductService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var productViewModel = new ProductViewModel();

            var token = HttpContext.Request.Cookies["accessToken"]?.Trim('"');

            if (token == "")
                return RedirectToAction("Index", "Account");


            productViewModel.AllProducts = await _apiService.GetAllAsync(authToken:token!);
            
            return View(productViewModel);
        }

        [Route("products/{id}")]
        public async Task<IActionResult> Detail(string id)
        {
            if(id == "")
                return RedirectToAction("Index", "Home");

            var result = await _apiService.GetByIdAsync(id);

            if(result == null!)
                return RedirectToAction("Index", "Home");
            
            return View(result);
        }
    }
}
