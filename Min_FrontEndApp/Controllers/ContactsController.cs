using Microsoft.AspNetCore.Mvc;
using Min_FrontEndApp.Models.ViewModels;
using Min_FrontEndApp.Services;

namespace Min_FrontEndApp.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactService _contactService;

        public ContactsController(ContactService apiService)
        {
            _contactService = apiService;
        }

        public IActionResult Index()
        {
            var contactViewModel = new ContactViewModel();

            return View(contactViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactViewModel contactViewModel)
        {
            if (!ModelState.IsValid)
                return View(contactViewModel);

            await _contactService.PostAsync(contactViewModel);

            return RedirectToAction("Index", "Home");
        }
    }
}
