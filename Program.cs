using System;
using System.Collections.Generic;

class Arac
{
    public string Marka { get; set; }
    public string Model { get; set; }
    public string Plaka { get; set; }
    public double Fiyat { get; set; }

    public Arac(string marka, string model, string plaka, double fiyat)
    {
        Marka = marka;
        Model = model;
        Plaka = plaka;
        Fiyat = fiyat;
    }

    public override string ToString()
    {
        return $"Marka: {Marka}, Model: {Model}, Plaka: {Plaka}, Fiyat: {Fiyat} TL";
    }
}

class AracYonetimSistemi
{
    private List<Arac> araclar = new List<Arac>();

    // Araç Ekleme
    public void AracEkle()
    {
        Console.Write("Araç Markası: ");
        string marka = Console.ReadLine();
        Console.Write("Araç Modeli: ");
        string model = Console.ReadLine();
        Console.Write("Araç Plakası: ");
        string plaka = Console.ReadLine();
        Console.Write("Araç Fiyatı: ");
        double fiyat = double.Parse(Console.ReadLine());

        Arac yeniArac = new Arac(marka, model, plaka, fiyat);
        araclar.Add(yeniArac);
        Console.WriteLine("Araç başarıyla eklendi!\n");
    }

    // Araç Silme
    public void AracSil()
    {
        Console.Write("Silmek istediğiniz aracın plakasını girin: ");
        string plaka = Console.ReadLine();
        Arac silinecekArac = araclar.Find(a => a.Plaka == plaka);

        if (silinecekArac != null)
        {
            araclar.Remove(silinecekArac);
            Console.WriteLine("Araç başarıyla silindi!\n");
        }
        else
        {
            Console.WriteLine("Araç bulunamadı.\n");
        }
    }

    // Araç Listeleme
    public void AraclariListele()
    {
        if (araclar.Count == 0)
        {
            Console.WriteLine("Hiç araç bulunmamaktadır.\n");
        }
        else
        {
            foreach (Arac arac in araclar)
            {
                Console.WriteLine(arac);
            }
            Console.WriteLine();
        }
    }

    // Araç Satış
    public void AracSat()
    {
        Console.Write("Satmak istediğiniz aracın plakasını girin: ");
        string plaka = Console.ReadLine();
        Arac satilacakArac = araclar.Find(a => a.Plaka == plaka);

        if (satilacakArac != null)
        {
            Console.WriteLine($"Araç Fiyatı: {satilacakArac.Fiyat} TL");
            Console.WriteLine("3 farklı indirim yüzdesi mevcuttur: 10%, 15%, 20%");
            Console.Write("Uygulamak istediğiniz indirimi seçin (10/15/20): ");
            int indirimYuzdesi = int.Parse(Console.ReadLine());

            double indirim = satilacakArac.Fiyat * indirimYuzdesi / 100;
            double satisTutari = satilacakArac.Fiyat - indirim;

            Console.WriteLine($"İndirim: {indirim} TL");
            Console.WriteLine($"Satış Tutarı: {satisTutari} TL\n");

            araclar.Remove(satilacakArac);  // Satılan araç listeden çıkarılıyor
        }
        else
        {
            Console.WriteLine("Araç bulunamadı.\n");
        }
    }

    // Araç Kiralama (Araç fiyatına göre ayarlanmış)
    public void AracKirala()
    {
        Console.Write("Kiralamak istediğiniz aracın plakasını girin: ");
        string plaka = Console.ReadLine();
        Arac kiralanacakArac = araclar.Find(a => a.Plaka == plaka);

        if (kiralanacakArac != null)
        {
            Console.Write("Kiralama süresi (gün): ");
            int kiralamaSuresi = int.Parse(Console.ReadLine());

            // Araç fiyatına göre günlük kiralama ücreti belirleniyor
            // Örneğin, aracın fiyatının %1'i günlük kiralama fiyatı olarak alınabilir.
            double gunlukKiralamaFiyati = kiralanacakArac.Fiyat * 0.01;

            double toplamFiyat = gunlukKiralamaFiyati * kiralamaSuresi;

            Console.WriteLine("2 farklı indirim yüzdesi mevcuttur: 5%, 10%");
            Console.Write("Uygulamak istediğiniz indirimi seçin (5/10): ");
            int indirimYuzdesi = int.Parse(Console.ReadLine());

            double indirim = toplamFiyat * indirimYuzdesi / 100;
            double kiralamaTutari = toplamFiyat - indirim;

            Console.WriteLine($"Araç Fiyatı: {kiralanacakArac.Fiyat} TL");
            Console.WriteLine($"Günlük Kiralama Ücreti: {gunlukKiralamaFiyati} TL");
            Console.WriteLine($"Toplam Kiralama Ücreti: {toplamFiyat} TL");
            Console.WriteLine($"İndirim: {indirim} TL");
            Console.WriteLine($"Kiralama Tutarı: {kiralamaTutari} TL\n");
        }
        else
        {
            Console.WriteLine("Araç bulunamadı.\n");
        }
    }
}

class Program
{
    static void Main()
    {
        AracYonetimSistemi sistem = new AracYonetimSistemi();
        int secim;

        do
        {
            Console.WriteLine("--- Araç Yönetim Sistemi ---");
            Console.WriteLine("1. Araç Ekle");
            Console.WriteLine("2. Araç Sil");
            Console.WriteLine("3. Araçları Listele");
            Console.WriteLine("4. Araç Sat");
            Console.WriteLine("5. Araç Kirala");
            Console.WriteLine("6. Çıkış");
            Console.Write("Seçiminizi yapın: ");
            secim = int.Parse(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    sistem.AracEkle();
                    break;
                case 2:
                    sistem.AracSil();
                    break;
                case 3:
                    sistem.AraclariListele();
                    break;
                case 4:
                    sistem.AracSat();
                    break;
                case 5:
                    sistem.AracKirala();
                    break;
                case 6:
                    Console.WriteLine("Çıkış yapılıyor...");
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim!\n");
                    break;
            }
        } while (secim != 6);
    }
}