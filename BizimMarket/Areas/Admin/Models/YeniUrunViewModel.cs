using BizimMarket.Attributes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BizimMarket.Areas.Admin.Models
{
    //https://stackoverflow.com/questions/35379309/how-to-upload-files-in-asp-net-core
    public class YeniUrunViewModel
    {
        [Required(ErrorMessage = "Ad alanı zorunlu ")]

        public string Ad { get; set; }
        [Required(ErrorMessage = "Fiyat alanı zorunlu ")]
        public decimal? Fiyat { get; set; }
        [Required(ErrorMessage = "Kategori alanı zorunlu ")]

        public int? KategoriId { get; set; }
        [GecerliResim(MaksimumDosyaBoyutuMb = 2)]
        public IFormFile Resim { get; set; } //Burada resmi direk dosya olarak tuttuk (interface) diske kaydetmek ıcın bunu yaptık. 
    }
}
