using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ConestogaVirtualGameStore.Models;
using Microsoft.AspNetCore.Http;

namespace ConestogaVirtualGameStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? statusCode)
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                StatusCode = statusCode.HasValue ? statusCode : null
            });
        }
    }
}
