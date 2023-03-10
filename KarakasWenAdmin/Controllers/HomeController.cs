using KarakasWenAdmin.Models;
using KarakasWenAdmin.Models.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace KarakasWenAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> Index()
        {
            List<Post> gonderiler = await karakasContext.Post
                .Include("Category")
                .Include("Comment")
                .ToListAsync();
            var mesaj = TempData["result"] == null ? string.Empty : TempData["result"];
            ViewData["result"] = mesaj;
            if (gonderiler != null)
            {
                return View(gonderiler);
            }

            return RedirectToAction("Error");
        }

        public async Task<IActionResult> Edit(string Id)
        {

            Post gonderi = await karakasContext.Post.SingleAsync(xy => xy.Id == Convert.ToInt32(Id));
            if (gonderi == null)
            {
                return NotFound();
            }
            return View(gonderi);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            if (ModelState.IsValid)
            {

                 return View(nameof(Index));    
            }
            else
            {
              return RedirectToAction("Error");
            }
           
        }
        [AllowAnonymous]
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