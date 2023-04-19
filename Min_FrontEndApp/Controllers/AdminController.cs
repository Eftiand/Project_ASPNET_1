using Microsoft.AspNetCore.Mvc;
using Min_FrontEndApp.Models.ViewModels;
using Min_FrontEndApp.Services;

namespace Min_FrontEndApp.Controllers;

public class AdminController : Controller
{
    private readonly AdminService _adminService;

    // GET
    public AdminController(AdminService adminService)
    {
        _adminService = adminService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await IsAuthorizedUser();
        
        if (!result)
            return RedirectToAction("SignIn", "Account");

        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Index(AdminAddProductViewModel model)
    {
        var resultAuthorizedUser = await IsAuthorizedUser();
        
        if(!resultAuthorizedUser)
            return RedirectToAction("SignIn", "Account");
        
        if (!ModelState.IsValid)
            return View(model);
        
        var token = HttpContext.Request.Cookies["accessToken"]?.Trim('"');
        
        var result = await _adminService.AddProductAsync(model, token!);

        return RedirectToAction("Index", "Home");
    }
    
    [HttpGet("CheckUser")]
    public async Task<bool> IsAuthorizedUser()
    {
        var token = HttpContext.Request.Cookies["accessToken"]?.Trim('"');

        if (string.IsNullOrEmpty(token))
            return false;
        
        var result = await _adminService.IsAuthorizedUser(authToken: token!);

        return result;
    }
}