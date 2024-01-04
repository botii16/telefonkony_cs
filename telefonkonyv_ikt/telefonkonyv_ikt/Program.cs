using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;

namespace telefonkonyv_ikt
{
    internal class Program
    {
        static List<string> nev = new List<string>();
        static List<BigInteger> tel = new List<BigInteger>();

        static void Main(string[] args)
        {
            bool egesz = true;

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("M = Névjegyzék megtekintése");
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("H = Névjegy hozzáadása");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("T = Névjegy törlése");
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("K = Kilépés");

            while (egesz)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.H:
                            Hozzaad();
                            break;
                        case ConsoleKey.M:
                            Kiir();
                            break;
                        case ConsoleKey.T:
                            Torles();
                            break;
                        case ConsoleKey.Q:
                            Console.Clear();
                            Console.SetCursorPosition(0, 0);
                            Console.WriteLine("M = Névjegyzék megtekintése");
                            Console.SetCursorPosition(0, 1);
                            Console.WriteLine("H = Névjegy hozzáadása");
                            Console.SetCursorPosition(0, 2);
                            Console.WriteLine("T = Névjegy törlése");
                            Console.SetCursorPosition(0, 4);
                            Console.WriteLine("K = Kilépés");
                            break;
                        case ConsoleKey.K:
                            Console.Clear();
                            Console.SetCursorPosition(0, 0);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Kilépés.");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(0, 0);
                            Console.WriteLine("Kilépés..");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(0, 0);
                            Console.WriteLine("Kilépés...");
                            egesz = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        static void Kiir()
        {
            Console.Clear();
            if (tel.Count == 0)
            {
                Console.WriteLine("Jelenleg nincs egy elmentett névjegy sem!");
                Console.WriteLine("Q = Vissza");
            }
            else
            {
                for (int i = 0; i < nev.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Név: {nev[i]}, Tel.: {tel[i]}");
                }
                Console.WriteLine("Q= Vissza");
            }
        }

        static void Hozzaad()
        {
            Console.Clear();
            while (true)
            {
                Console.Write("Név:");
                string nev2 = Console.ReadLine();

                if (string.IsNullOrEmpty(nev2))
                {
                    Console.WriteLine("Hiba: Kérem, adja meg a nevet!");
                    continue;
                }

                Console.Write("Telefonszám:");
                string telInput = Console.ReadLine();

                if (string.IsNullOrEmpty(telInput))
                {
                    Console.WriteLine("Hiba: Kérem, adja meg a telefonszámot!");
                    continue;
                }

                if (!BigInteger.TryParse(telInput, out BigInteger tel2))
                {
                    Console.WriteLine("Hiba: Érvénytelen telefonszám formátum!");
                    continue;
                }

                nev.Add(nev2);
                tel.Add(tel2);

                Console.WriteLine("Sikeresen elmentve!\nSzeretne még egy névjegyet hozzáadni vagy vissza szeretne lépni a menübe? Nyomja meg a H/Q gombot");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Q)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("M = Névjegyzék megtekintése");
                    Console.SetCursorPosition(0, 1);
                    Console.WriteLine("H = Névjegy hozzáadása");
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("T = Névjegy törlése");
                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine("K = Kilépés");
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.H)
                {
                    break;
                }
            }
        }
        static void Torles()
        {
            Console.Clear();

            while (true)
            {
                if (tel.Count == 0)
                {
                    Console.WriteLine("Jelenleg nincs egy elmentett telefon szám se!\nElőször adjon hozzá egy névjegyet!");
                    Console.WriteLine("Q = Vissza");
                    break;
                }
                else
                {
                    Console.Clear();
                    for (int i = 0; i < nev.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. Név: {nev[i]}, Tel.: {tel[i]}");
                    }
                    Console.WriteLine("Q= Vissza");
                    Console.Write("Adja meg a törölni kívánt névjegy számát: ");
                    int torolSzam;

                    if (int.TryParse(Console.ReadLine(), out torolSzam) && torolSzam >= 1 && torolSzam <= nev.Count)
                    {
                        nev.RemoveAt(torolSzam - 1);
                        tel.RemoveAt(torolSzam - 1);
                        Console.WriteLine("Sikeresen törölve!\nSzeretne még egy névjegyet törölni vagy vissza szeretne lépni a menübe? Nyomja meg a T/Q gombot");
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        if (keyInfo.Key == ConsoleKey.Q)
                        {
                            Console.Clear();
                            Console.SetCursorPosition(0, 0);
                            Console.WriteLine("M = Névjegyzék megtekintése");
                            Console.SetCursorPosition(0, 1);
                            Console.WriteLine("H = Névjegy hozzáadása");
                            Console.SetCursorPosition(0, 2);
                            Console.WriteLine("T = Névjegy törlése");
                            Console.SetCursorPosition(0, 4);
                            Console.WriteLine("K = Kilépés");
                            break;
                        }
                        else if (keyInfo.Key == ConsoleKey.T)
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hiba: Érvénytelen szám!");
                        Thread.Sleep(1500);
                    }
                }
            }
        }
    }
}
