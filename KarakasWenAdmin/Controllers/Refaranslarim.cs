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
            var mesaj = TempData["result"] == null ? string.Empty : TempData["result"];
            ViewData["result"] = mesaj;
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
            if (ModelState.IsValid)
            {
                Referanslar refe = karakasContext.Referanslar.FirstOrDefault(x => x.Id == referans.Id);
                if(refe == null)
                {
                    return RedirectToAction(nameof(HomeController),nameof(HomeController.Error));
                }
                refe.Aciklama = referans.Aciklama;
                refe.Kurum=referans.Kurum;
                refe.LinUrl=referans.LinUrl;
                refe.Baslik = referans.Baslik;
                refe.CalismaSuresi=referans.CalismaSuresi;
                refe.Platform=referans.Platform;
                refe.ResimAdres = referans.ResimAdres;
                refe.Yayinda = refe.Yayinda;
                karakasContext.Update(refe);
               var son = karakasContext.SaveChanges();
                if(son==1)
                {
                    TempData["result"] = "Ok";
                }
               

            }
            ViewData["sonuc"] = "Referans başarı ile güncellendi";
            return RedirectToAction(nameof(Index));
        }

    }
}
