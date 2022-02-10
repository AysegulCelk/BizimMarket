using BizimMarket.Areas.Admin.Models;
using BizimMarket.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;

namespace BizimMarket.Areas.Admin.Controllers
{
    [Area("admin")] //dogru yer aktif olsun dıye 
    public class UrunlerController : Controller
    {
        private readonly BizimMarketContext _db;
        private readonly IWebHostEnvironment _env;

        public UrunlerController(BizimMarketContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.Urunler.Include(x => x.Kategori).ToList()); //include : c# entegre edılmıs sorulama 
        }
        public IActionResult Yeni() //get
        {
            ViewBag.Kategoriler = _db.Kategoriler
                .Select(x => new SelectListItem(x.Ad, x.Id.ToString()))
                .ToList();
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Yeni(YeniUrunViewModel vm) //model binding :bir action metod da bir complex tip verildiğinde onun propertylerine formdan gelen dataların aktarılması 'dır. Ancak model bunding işlemi esnasında propertylerın ustundekı valıdatıon entrubitutlarda dikkare alınır Requided eger gecerlı degılse uygun hata mesajı model state controllera eklenır. isValıd=false
        {
            //tokatlama:  resim yerine pdf yuklemeye kalktık buradaki if i geçemediği için alttaki if false doner ve girmez
            //#region Resim Geçerlilik=> !!!!!!! anttirubute ile hallledik !!!!!!!!!!!
            //if (vm.Resim != null)
            //{
            //    if (!vm.Resim.ContentType.StartsWith("image/"))
            //        ModelState.AddModelError("Resim", "Geçersiz resim dosyası.");
            //    else if (vm.Resim.Length > 1 * 1024 * 1024)
            //        ModelState.AddModelError("Resim", "Resim dosyası 1MB büyük olamaz");

            //}

            //#endregion

            if (ModelState.IsValid)
            {
                #region Resim Kaydetme
                string dosyaAdi = null;
                if (vm.Resim != null)
                {
                    dosyaAdi = Guid.NewGuid() + Path.GetExtension(vm.Resim.FileName); // Guid ile resme kendımız benzersiz bir ad verdık, +path ile kullanıcının yukledıgı resmın jpg ya da png olması fark etmeksızın uzantısını aldı.
                    string kaydetmeYolu = Path.Combine(_env.WebRootPath, "img", "Urunler", dosyaAdi); // IWebHostEnvironment env
                    /*string kaydetmeYolu = @"D:\BoostAradanSonra\08-02-2022-teori\BizimMarket\BizimMarket\wwwroot\img\Urunler\" + dosyaAdi; *///böyle vermek mantıklı değil cunku baska bırı kullandıgında dosya yolumuz aynı olmıycak 
                    using (FileStream fs = new FileStream(kaydetmeYolu, FileMode.Create)) //akıntı: ram ile harddisk arasında baglantı kurduk.
                    {
                        vm.Resim.CopyTo(fs);

                    }
                }


                #endregion
                Urun urun = new Urun()
                {
                    Ad = vm.Ad,
                    Fiyat = vm.Fiyat.Value,
                    KategoriId = vm.KategoriId.Value,
                    ResimYolu = dosyaAdi

                };
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
