using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eTicaretProje.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()
            {
                new Category(){ Name = "Elbise", Description = "Elbise ürünleri"},
                new Category(){ Name = "Triko&Kazak", Description = "Triko&Kazak ürünleri"},
                new Category(){ Name = "Mont-Kaban", Description = "Mont-Kaban ürünleri"},
                new Category(){ Name = "Bot", Description = "Bot ürünleri"},

            };

            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();

            var urunler = new List<Product>()
            {
                new Product(){ Name = "U.S. Polo Assn. Kadın Lacivert Triko Elbise 50277304-VR033",Description = "MARKA: U.S. Polo Assn. CİNSİYET: Kadın ÜRÜN TANIMI: Triko Elbise RENK: Lacivert FİT: Regular KUMAŞ: %100 Akrilik TANIMLAYICI KOD: G082SZ0TE.000.1753806.VR033 MODEL BİLGİLERİ: Boy:174|Kilo:62|Göğüs:83|Bel:61|Basen:87|Beden:26 .S .36|ÜrünBeden:S", Price =1699 , Stock =500 , IsApproved =true , CategoryId = 1,IsHome = true,Image = "polo.jpg"},
                new Product(){ Name = "İpekyol Elbise ",Description = "IPEKYOL Elbise Cinsiyet:Kadın ,Kalıp:Sütun ,Yaka Stili:Kruvaze Yaka Stil:Günlük Kol Boyu:Kolsuz Desen:Düz Renk", Price =5999 , Stock =500 , IsApproved =true , CategoryId = 1,IsHome = true,Image = "ipekyol.jpg"},
                new Product(){ Name = "Koton Şort Tulum Drape Yaka Düğme Detaylı",Description = "tulum modellerini tamamlayarak, kombininizi zenginleştiren aksesuarlarımıza mutlaka göz atın! ", Price =799 , Stock =500 , IsApproved =true , CategoryId = 1,IsHome = true,Image = "koton.jpg"},
                new Product(){ Name = "No Matter What Parlak Taş Kaplı Tül Elbise",Description = "Parlak Taş Kaplı Tül Elbise klasik stili ile özel günlerinizde star siz olun!", Price =1190 , Stock =500 , IsApproved =true , CategoryId = 1,IsHome = true,Image = "pullu.jpg"},
                new Product(){ Name = "TOMMY HILFIGER KADIN ELBISE  Cinsiyet:Kadın ,Elbise Tipi:T-Shirt Elbise ,Kalıp:Rahat ,Yaka Stili: Bisiklet Yaka, Stil:Günlük, Kol Boyu:Uzun Kol, Desen:Grafik", Price =4890 , Stock =500 , IsApproved =true , CategoryId = 1,Image = "tommy.jpg"},


                new Product(){ Name = " U.s. Polo Assn. Kadın Lacivert Triko Kazak ",Description = "  MODEL BİLGİLERİ: Boy:175|Kilo:55|Göğüs:87|Bel:64|Basen:90|Beden:26 .S .36|ÜrünBeden:S  ", Price =1349 , Stock =0 , IsApproved =true , CategoryId = 2,IsHome = true,Image = "uspakazak.jpg"},
                new Product(){ Name = " No Matter What Kadın Kazak ",Description = " No Matter What Kadın Kazak parlak görünümüyle şık gecelere damga vuracaktır.   ", Price =800 , Stock =0 , IsApproved =false , CategoryId = 2,IsHome = true,Image = "kazak2.jpg"},
                new Product(){ Name = " Twist Trıko ",Description = "Yıkama Talimati: Makinada yıkama, max.30°, hassasAğartma yapılamaz.Düz şekilde kurutunuz.Düşük sıcaklıkta, max.110C ütülenebilir.Trikloretilen hariç her tip solvent ile kuru temizleme yapılabilir.", Price =1599 , Stock =0 , IsApproved =true , CategoryId = 2,IsHome = true,Image = "twist.jpg"},
                new Product(){ Name = " Cool Tarz Kadın Kırmızı Cristmas Yılbaşı Kazağı ",Description = "Mankenlerin Üzerindeki Ürün M BedendirModelin Ölçüleri: Boy: 1.77, Göğüs: 90, Bel: 65, Kalça: 90Ürün İçeriği: %90 AKRİLİK %10 polyester    ", Price =329 , Stock =0 , IsApproved =true , CategoryId = 2,IsHome = true,Image = "yilbasikazak.jpg"},
                new Product(){ Name = " Desen Triko Kadın Dik Yaka Sarmaşık Çiçekli Yün Kaban M.yeşili ",Description = " Stüdyo Çekim Ortamında Bulunan Işık Ve Gölgelenmelere İstinaden Görsellerde Renk Farklılıkları Veya Parlamalar Oluşabilir.   ", Price =2699 , Stock =0 , IsApproved =true , CategoryId = 2,IsHome = true,Image = "kalin.jpg"},

                new Product(){ Name = " Mai Collection Moscow Bej Kaşe Kaban ",Description = "Katlı Klapalı Uzun Kollu Önü Düğmeli İki Yanı Cepli Astarlı   ", Price =2700 , Stock =0 , IsApproved =true , CategoryId = 3,IsHome = true,Image = "kaban.jpg"},
                new Product(){ Name = " İpekyol Suni Kürk Garnili Kaban ",Description = " Yıkama yapılmaz.Ağartma yapılamaz.Santrifüjlü makinada kurutma yapılamaz.Düşük sıcaklıkta, max.110C ütülenebilir.Kuru temizleme yapılmaz.   ", Price =5400 , Stock =0 , IsApproved =true , CategoryId = 3,IsHome = true,Image = "ipekyolkaban.jpg"},
                new Product(){ Name = " U.S. Polo Assn. Kadın Coconut Mont 50271235-VR153 ",Description = " şişme üşütmez mont   ", Price =5399 , Stock =0 , IsApproved =true , CategoryId = 3,IsHome = true,Image = "sismemont.jpg"},
                new Product(){ Name = "Lufian Halsey Kaztüyü Kadın Mont Koyu Kırmızı  ",Description = "Halsey Kaztüyü Kadın Mont %100 Polyester Dokuma Bayan Mont    ", Price =3399 , Stock =0 , IsApproved =true , CategoryId = 3,IsHome = true,Image = "halse.jpg"},
                new Product(){ Name = " Lufian Fem Kaztüyü Kadın Mont Siyah ",Description = "Fem Kaztüyü Kadın Mont Polyamid Dokuma Bayan Mont    ", Price =2999 , Stock =0 , IsApproved =true , CategoryId = 3,IsHome = true,Image = "luf.jpg"},

                new Product(){ Name = " Koç Yiğitler Trendayakkabı - Pine 203 Bej Topuklu Kadın Kısa Çizme ",Description = " Sezon: 2023 - 2024 Sonbahar-Kış   ", Price =1288 , Stock =0 , IsApproved =true , CategoryId = 4,IsHome = true,Image = "cizme.jpg"},
                new Product(){ Name = " Bruce Siyah Renkli Ince Topuklu Kadın Streç Bot ",Description = " Topuk Boyu - 8 cm  Kalıp - Tam Kalıp/Standart   ", Price =942 , Stock =0 , IsApproved =true , CategoryId = 4,IsHome = true,Image = "cizme2.jpg"},
                new Product(){ Name = "Shoeberry Kadın Freyja Siyah Hakiki Deri Postal Bot",Description = " Hakiki Deri Malzemeden Üretilmiştir.Topuk Boyu 4 Cm'dir.   ", Price =3400 , Stock =0 , IsApproved =true , CategoryId = 4,IsHome = true,Image = "bot.jpg"},
                new Product(){ Name = "Hobby 21447 Hakiki Deri Kadın Günlük Bot  ",Description = " HAKİKİ DERİ (FLOTER)   ", Price =3400 , Stock =0 , IsApproved =true , CategoryId = 4,IsHome = true,Image = "deri.jpg"},
                new Product(){ Name = " Albini Kahve Taba Deri Kadın Postal Bot Ayakkabı ",Description = "ALBİNİ TERMO ESNEK KAYMAZ TABANLI ,HAKİKİ SU GEÇİRMEZ DERİ,TER VE KOKU YAPMAYAN SICAK İÇ ASTARLI ,5 CM TOPUKLU,FERMUARLI KOLAY GİYİDİRİMLİ ,GÜNLÜK KULLANIM KAHVE TABA RENKLİ KADIN POSTAL BOT AYAKKABI    ", Price =3400 , Stock =0 , IsApproved =true , CategoryId = 4,IsHome = true,Image = "albini.jpg"},
            };

            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }

            context.SaveChanges();

            base.Seed(context);
        }

    }
}