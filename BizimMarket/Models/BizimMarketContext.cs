using Microsoft.EntityFrameworkCore;

namespace BizimMarket.Models
{
    public class BizimMarketContext:DbContext
    {
        public BizimMarketContext(DbContextOptions<BizimMarketContext>options):base(options)
        {

        }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Urun> Urunler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategori>().HasData(
                new Kategori() { Id = 1, Ad = "Atıştırmalık" },
                new Kategori() { Id = 2, Ad = "Dondurma" },
                new Kategori() { Id = 3, Ad = "Fırın" }
                );
            modelBuilder.Entity<Urun>().HasData(
                new Urun() { Id = 1, Ad = "Kinder Joy", Fiyat = 7.90m, ResimYolu = "KinderJoy.jpg", KategoriId = 1 },
                new Urun() { Id = 2, Ad = "Toblerone Sütlü Çikolata 100g", Fiyat = 18.90m, ResimYolu = "Toblerone.jpg", KategoriId = 1 },
                new Urun() { Id = 3, Ad = "Tadelle Fındık Dolgulu Sütlü Çikolata 30g", Fiyat = 4.90m, ResimYolu = "Tadelle.jpg", KategoriId = 1 },
                new Urun() { Id = 4, Ad = "Algida Maraş Usulü Sade Çikolata Dondurma 500ml ", Fiyat = 28.50m, ResimYolu = "AlgidaMaras.jpg", KategoriId = 2 },
                new Urun() { Id = 5, Ad = "Carte d'Or Selection Meyve Şöleni 850ml ", Fiyat = 36.90m, ResimYolu = "MeyveSoleni.jpg", KategoriId = 2 },
                new Urun() { Id = 6, Ad = "Minik Sandviç 10'lu ", Fiyat = 17.90m, ResimYolu = "MinikSandvic.jpg", KategoriId = 3 }
                );
        }
    }
}
