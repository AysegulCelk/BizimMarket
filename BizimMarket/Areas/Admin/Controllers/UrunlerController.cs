using BizimMarket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BizimMarket.Areas.Admin.Controllers
{
    [Area("admin")] //dogru yer aktif olsun dıye 
    public class UrunlerController : Controller
    {
        private readonly BizimMarketContext _db;

        public UrunlerController(BizimMarketContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Urunler.Include(x => x.Kategori).ToList()); //include : c# entegre edılmıs sorulama 
        }
        public IActionResult Yeni() //get
        {
            ViewBag.Kategoriler=_db.Kategoriler
                .Select(x=>new SelectListItem(x.Ad, x.Id.ToString()))
                .ToList();
            return View(); 
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Yeni(Urun urun)
        {
            if (ModelState.IsValid)
            {
                _db.Add(urun);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Kategoriler = _db.Kategoriler
                .Select(x => new SelectListItem(x.Ad, x.Id.ToString()))
                .ToList();
            return View();
        }
    }
}
