using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BizimMarket.Models
{
    public class Kategori
    {
        
        public int Id { get; set; }
        [Required, MaxLength(100)] //zorunlu hale getirdik 
        public string Ad { get; set; }
        public List<Urun> Urunler { get; set; } //Icollection mı yapmak daha ıyı bu mu sorusunun cevabını en ıyı micdocs dan ogrenırsınız. ef core one two many (googleda arama yaptı ıkı turlude ornek oldugunu gorduk ) Genellikle list kullanmıslar


    }
}
