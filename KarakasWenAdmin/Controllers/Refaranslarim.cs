using KarakasWenAdmin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KarakasWenAdmin.Controllers
{
    [Authorize]
    public class Refaranslarim : Controller
    {
        private readonly KarakasContext karakasContext;
        public Refaranslarim(KarakasContext karakasContext)
        {
            this.karakasContext = karakasContext;
        }

        public IActionResult Index()
        {
            List<Referanslar> referans = karakasContext.Referanslar.ToList();
            return View(referans);
        }
       public IActionResult Edit(string Id)
        {
            
            Referanslar? referans = karakasContext.Referanslar.FirstOrDefault(xy => xy.Id == Convert.ToInt32(Id));
            if (referans == null)
            {
                return NotFound();
            }
            return View(referans);
        }

        [HttpPost]
        public IActionResult Edit(Referanslar referans)
        {
            ViewData["sonuc"] = "Referans başaı ile güncellendi";
            return View(referans);
        }

    }
}
