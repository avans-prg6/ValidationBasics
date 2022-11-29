using Microsoft.AspNetCore.Mvc;
using RoosterApp.Models;
using System.Diagnostics;

namespace RoosterApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            FormulierVM formulier = new FormulierVM();
            return View(formulier);
        }

        [HttpPost]
        public IActionResult Verstuur(FormulierVM formulier)
        {
            if(!ModelState.IsValid)
            {
                return View("Index", formulier);
            }

            //yay we did the thing!
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}