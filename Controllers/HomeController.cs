using Athentification.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Athentification.Controllers
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
            
            return View();
        }

        public IActionResult ShowImagesFromFolder()
        {
            //Get the Folder Path
            var imageFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/NewFolder");
            //Get the File Path
            var imageFileNames = Directory.EnumerateFiles(imageFolder)
                                          .Select(fn => Path.GetFileName(fn));
            //Return all the Images to the View
            return View(imageFileNames);
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
