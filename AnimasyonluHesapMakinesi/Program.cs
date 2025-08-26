using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static List<string> islemGecmisi = new List<string>();
    static string[] menuItems = {
        "Toplama (+)",
        "Çıkarma (-)",
        "Çarpma (*)",
        "Bölme (/)",
        "Üs Alma (^)",
        "Mod Alma (%)",
        "Karekök (√)",
        "Faktöriyel (!)",
        "İşlem Geçmişi",
        "Çıkış"
    };

    static void Main()
    {
        ShowOpeningAnimation();
        bool devam = true;

        while (devam)
        {
            int secim = ShowAnimatedMenu();
            Console.Clear();

            switch (secim)
            {
                case 0: Toplama(); break;
                case 1: Cikarma(); break;
                case 2: Carpma(); break;
                case 3: Bolme(); break;
                case 4: UsAlma(); break;
                case 5: ModAlma(); break;
                case 6: Karekok(); break;
                case 7: Faktoriyel(); break;
                case 8: GecmisiGoster(); break;
                case 9: devam = false; break;
            }

            if (devam)
            {
                Console.WriteLine("\nDevam etmek için bir tuşa basın...");
                Console.ReadKey(true);
                Console.Clear();
            }
        }

        ShowInfoBox("Programdan çıkılıyor. Teşekkürler!");
    }

    static void ShowOpeningAnimation()
    {
        string title = "=== GELİŞMİŞ ANİMASYONLU HESAP MAKİNESİ ===";
        Console.ForegroundColor = ConsoleColor.Cyan;
        foreach (char c in title)
        {
            Console.Write(c);
            Thread.Sleep(15);
        }
        Console.ResetColor();
        Console.WriteLine("\n");
        Thread.Sleep(300);
    }

    static int ShowAnimatedMenu()
    {
        int index = 0;
        ConsoleKey key;

        do
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== Menü ===\n");
            Console.ResetColor();

            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == index)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($" > {menuItems[i]}");
                        Thread.Sleep(50);
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.ResetColor();
                        Console.WriteLine($"   {menuItems[i]}");
                        Thread.Sleep(50);
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                    }
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($" > {menuItems[i]}");
                }
                else
                {
                    Console.ResetColor();
                    Console.WriteLine($"   {menuItems[i]}");
                }
            }

            key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.UpArrow && index > 0) index--;
            else if (key == ConsoleKey.DownArrow && index < menuItems.Length - 1) index++;

        } while (key != ConsoleKey.Enter);

        Console.ResetColor();
        return index;
    }

    static double GetDoubleInput(string mesaj)
    {
        double sayi;
        Console.Write(mesaj);
        while (!double.TryParse(Console.ReadLine(), out sayi))
        {
            ShowErrorBox("Hatalı giriş! Lütfen geçerli sayı girin.");
            Console.Beep(500, 200); // Sesli uyarı
            Console.Write(mesaj);
        }
        return sayi;
    }

    static int GetIntInput(string mesaj, int min = int.MinValue, int max = int.MaxValue)
    {
        int sayi;
        Console.Write(mesaj);
        while (!int.TryParse(Console.ReadLine(), out sayi) || sayi < min || sayi > max)
        {
            ShowErrorBox($"Hatalı giriş! {min}-{max} arasında sayı girin.");
            Console.Beep(500, 200); // Sesli uyarı
            Console.Write(mesaj);
        }
        return sayi;
    }

    static void ShowErrorBox(string mesaj)
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($" [!] {mesaj} ");
        Console.ResetColor();
        Thread.Sleep(300);
    }

    static void ShowInfoBox(string mesaj)
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($" [i] {mesaj} ");
        Console.ResetColor();
        Thread.Sleep(300);
    }

    static void ShowResultBox(string mesaj)
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($" {mesaj} ");
        Console.ResetColor();
        islemGecmisi.Add(mesaj);
        Thread.Sleep(300);
    }

    static void ShowLoading(string mesaj)
    {
        Console.Write(mesaj + " ");
        for (int i = 0; i < 20; i++)
        {
            Console.Write("█");
            Thread.Sleep(40);
        }
        Console.WriteLine();
    }

    // Matematiksel işlemler
    static void Toplama()
    {
        double a = GetDoubleInput("1. sayı: ");
        double b = GetDoubleInput("2. sayı: ");
        ShowResultBox($"{a} + {b} = {Math.Round(a + b, 2)}");
    }

    static void Cikarma()
    {
        double a = GetDoubleInput("1. sayı: ");
        double b = GetDoubleInput("2. sayı: ");
        ShowResultBox($"{a} - {b} = {Math.Round(a - b, 2)}");
    }

    static void Carpma()
    {
        double a = GetDoubleInput("1. sayı: ");
        double b = GetDoubleInput("2. sayı: ");
        ShowResultBox($"{a} * {b} = {Math.Round(a * b, 2)}");
    }

    static void Bolme()
    {
        double a = GetDoubleInput("1. sayı: ");
        double b = GetDoubleInput("2. sayı: ");
        if (b == 0) ShowErrorBox("Bir sayıyı 0'a bölemezsiniz!");
        else ShowResultBox($"{a} / {b} = {Math.Round(a / b, 2)}");
    }

    static void UsAlma()
    {
        double a = GetDoubleInput("Taban: ");
        double b = GetDoubleInput("Üs: ");
        ShowResultBox($"{a} ^ {b} = {Math.Round(Math.Pow(a, b), 2)}");
    }

    static void ModAlma()
    {
        double a = GetDoubleInput("1. sayı: ");
        double b = GetDoubleInput("2. sayı: ");
        if (b == 0) ShowErrorBox("Mod işlemi için ikinci sayı 0 olamaz!");
        else ShowResultBox($"{a} % {b} = {Math.Round(a % b, 2)}");
    }

    static void Karekok()
    {
        double a = GetDoubleInput("Sayı: ");
        if (a < 0) ShowErrorBox("Negatif sayının karekökü alınamaz!");
        else ShowResultBox($"√{a} = {Math.Round(Math.Sqrt(a), 2)}");
    }

    static void Faktoriyel()
    {
        int n = GetIntInput("Sayı (0-20): ", 0, 20);
        ShowLoading("Hesaplanıyor");
        long f = 1;
        for (int i = 2; i <= n; i++) f *= i;
        ShowResultBox($"{n}! = {f}");
    }

    static void GecmisiGoster()
    {
        if (islemGecmisi.Count == 0)
        {
            ShowInfoBox("Henüz işlem yapılmadı.");
            return;
        }

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("=== İşlem Geçmişi ===");
        Console.ResetColor();

        foreach (var islem in islemGecmisi)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" {islem} ");
            Console.ResetColor();
            Thread.Sleep(100);
        }
    }
}
