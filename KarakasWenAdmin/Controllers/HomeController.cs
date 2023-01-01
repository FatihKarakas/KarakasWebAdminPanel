using KarakasWenAdmin.Models;
using KarakasWenAdmin.Models.Entitys;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KarakasWenAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KarakasContext karakasContext;
        public HomeController(ILogger<HomeController> logger, KarakasContext karakasContext)
        {
            _logger = logger;
            this.karakasContext = karakasContext;
        }

        public IActionResult Index()
        {
            UserControl userControl = karakasContext.UserControl.FirstOrDefault();
            if(userControl != null)
            {
                 var test = userControl.IsActive;
            }
            
            return View(userControl);
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