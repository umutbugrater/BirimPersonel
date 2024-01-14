using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjeCore.Models;

namespace ProjeCore.Controllers
{
    public class PersonelimController : Controller
    {
        Context c = new Context();
        [Authorize]
        public IActionResult Index()
        {
            var degerler = c.Personels.Include(x => x.Birim).ToList();
            return View(degerler);
        }

        [HttpGet]
        public IActionResult YeniPersonel()
        {
            List<SelectListItem> degerler = (from x in c.Birims.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.BirimAd,
                                                 Value = x.BirimID.ToString()
                                             }
                                             ).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public IActionResult YeniPersonel(Personel p)
        {
            var per = c.Birims.Where(x => x.BirimID == p.Birim.BirimID).FirstOrDefault();
            p.Birim = per;
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult PersonelSil(int id)
        {
            c.Personels.Remove(c.Personels.Find(id));
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult PersonelGuncelle(int id)
        {
            var value = c.Personels.Find(id);

            List<SelectListItem> degerler = (from x in c.Birims.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.BirimAd,
                                                 Value = x.BirimID.ToString()
                                             }
                                             ).ToList();
            ViewBag.dgr = degerler;
            return View(value);
        }

        [HttpPost]
        public IActionResult PersonelGuncelle(Personel p)
        {
            var value = c.Personels.Find(p.PersonelID);
            value.Ad = p.Ad;
            value.Soyad = p.Soyad;
            value.Sehir = p.Sehir;
            value.BirimID = p.Birim.BirimID;
            c.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
