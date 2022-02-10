using System.ComponentModel.DataAnnotations;

namespace BizimMarket.Models
{
    public class Urun
    {
        public int Id { get; set; }
        [Required, MaxLength(100)] //zorunlu hale getirdik 
        public string Ad { get; set; }
        
        public decimal Fiyat { get; set; }
        public string ResimYolu { get; set; }

        //urun açıklamsı eklenebilir 
        //[Required( ErrorMessage="Kategori alanı zorunludur.")] bu sekilde hata mesajlarını gostere bılırdık 
        public int KategoriId { get; set; } //struct
        public Kategori Kategori { get; set; }


    }
}
