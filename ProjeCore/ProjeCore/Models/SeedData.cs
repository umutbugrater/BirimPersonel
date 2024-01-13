using Microsoft.EntityFrameworkCore;

namespace ProjeCore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            Context context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<Context>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Birims.ToList().Any())
            {
                context.Birims.Add(new Birim { BirimAd = "Muhasebe" });
                context.Birims.Add(new Birim { BirimAd = "Satın Alma" });
                context.Birims.Add(new Birim { BirimAd = "Danışma" });
                context.Birims.Add(new Birim { BirimAd = "Müdür" });
                context.Birims.Add(new Birim { BirimAd = "Bilgi İşlem" });
                context.SaveChanges();
            }

            if (!context.Personels.ToList().Any())
            {
                context.Personels.Add(new Personel { Ad = "Mesut", Soyad = "Yücedağ", Sehir = "Adana", BirimID = 2});
                context.Personels.Add(new Personel { Ad = "Turgay", Soyad = "Karahasan", Sehir = "Adana", BirimID = 3 });
                context.Personels.Add(new Personel { Ad = "Ece", Soyad = "Naz", Sehir = "İstanbul", BirimID = 1});
                context.Personels.Add(new Personel { Ad = "Mehmet", Soyad = "Öztürk", Sehir = "Bursa", BirimID = 2 });
                context.Personels.Add(new Personel { Ad = "Veysel ", Soyad = "Aslan", Sehir = "Antalya", BirimID = 5 });
                context.Personels.Add(new Personel { Ad = "Ali", Soyad = "Yıldız", Sehir = "Trabzon", BirimID = 2 });
                context.Personels.Add(new Personel { Ad = "Umut Buğra", Soyad = "TER", Sehir = "Ankara", BirimID = 5 });
                context.SaveChanges();

            }

            if (!context.Admins.ToList().Any())
            {
                context.Admins.Add(new Admin { Kullanici = "umut", Sifre = "123" });
                context.SaveChanges();

            }
        }
    }
}
