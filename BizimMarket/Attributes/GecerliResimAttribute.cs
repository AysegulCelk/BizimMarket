using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BizimMarket.Attributes
{
    public class GecerliResimAttribute : ValidationAttribute
    {
        public int MaksimumDosyaBoyutuMb { get; set; } = 1;
        //kendi antributemizi yapıyoruz 
        public override bool IsValid(object value)
        {
            if (value == null) return true; //herahngi bir sey girmediyse sorguya gerek yok 
            IFormFile resim = (IFormFile)value; //IFormFile cevirdik 
            if (!resim.ContentType.StartsWith("image/"))//image ile baslayıp başlamadıgını kontrol ettık 
            {
                ErrorMessage = "Geçersiz resim dosyası.";
                return false;
            }
            else if (resim.Length > MaksimumDosyaBoyutuMb * 1024 * 1024)
            {
                ErrorMessage = $"Resim dosyası {MaksimumDosyaBoyutuMb}'dan büyük olmaz.";
                return false;
            }
            return true;

        }
    }
}
