using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KarakasWenAdmin.Controllers
{
    public class UserAccountController : Controller
    {
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
