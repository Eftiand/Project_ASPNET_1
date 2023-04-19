using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Min_FrontEndApp.Models.DTO;
using Min_FrontEndApp.Models.ViewModels;
using Min_FrontEndApp.Services;

namespace Min_FrontEndApp.Controllers;

public class HomeController : Controller
{
    private readonly ProductService _apiService;
    private readonly AdminService _adminService;
    public HomeController(ProductService apiService, AdminService adminService)
    {
        _apiService = apiService;
        _adminService = adminService;
    }

    public async Task<IActionResult> Index()
    {
        var homeViewModel = new HomeViewModel();
        
        homeViewModel.Featured = await _apiService.GetStatusAsync("featured");
        homeViewModel.New = await _apiService.GetStatusAsync("new");
        homeViewModel.Popular = await _apiService.GetStatusAsync("popular");


        return View(homeViewModel);
    }
}
