using KarakasWenAdmin.Models;
using KarakasWenAdmin.Models.Entitys;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            List<UserControl> userControl = karakasContext.UserControl.ToList();
            List<Mesajlar> posts = karakasContext.Mesajlar.ToList();
            List<Post> gonderiler = karakasContext.Post.ToList();
            var mesaj = TempData["result"] == null ? string.Empty : TempData["result"];
            ViewData["result"] = mesaj;
            if (userControl != null)
            {
                return View(userControl);
            }

            return RedirectToAction("Error");
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

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}