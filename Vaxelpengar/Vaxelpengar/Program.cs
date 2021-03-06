﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaxelpengar
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variablerna.
            double totalSumma;
            int kontanter;
            uint attBetala;
            double avrundningsTal;
            int tillbaka;
            
            // Läs in totalsumman.
            while (true)
            {
                try
                {
                    Console.Write("Ange den totala köpsumman: ");
                    totalSumma = double.Parse(Console.ReadLine());

                    if (totalSumma < 1)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Fel! Totalsumman är för liten, köpet kunde inte genomföras.");
                        Console.ResetColor();
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Otillåten inmatning, försök igen.");
                    Console.ResetColor();
                } 
            }

            // Läs in kontantbelopp
            while (true)
            {
                try
                {
                    Console.Write("Ange mottaget belopp     : ");
                    kontanter = int.Parse(Console.ReadLine());

                    if (kontanter < 1)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Fel! Det går inte att betala med minus.");
                        Console.ResetColor();
                    }
                    else if (kontanter < totalSumma)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Fel! Pengarna räcker inte.");
                        Console.ResetColor();
                    }                    
                    else
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Otillåten inmatning, försök igen.");
                    Console.ResetColor();
                } 
            }

            // Avrunda
            attBetala = (uint)Math.Round(totalSumma);
            avrundningsTal = attBetala - totalSumma;
            tillbaka = kontanter - (int)attBetala;
            
            // Kvittoutskrift
            Console.WriteLine();
            Console.WriteLine(" KVITTO                      ");
            Console.WriteLine("-----------------------------");
            Console.WriteLine(" Totalt        : {0, 8} kr", totalSumma);

            // Visa inte öresavrundningen om ingen avrundning skett.
            if (avrundningsTal != 0)
            {
            Console.WriteLine(" Öresavrundning: {0, 8:f2} kr", avrundningsTal); 
            }

            Console.WriteLine(" Att betala    : {0, 8} kr", attBetala);
            Console.WriteLine(" Kontant       : {0, 8} kr", kontanter);
            Console.WriteLine(" Tillbaka      : {0, 8} kr", (tillbaka));
            Console.WriteLine("-----------------------------");
            Console.WriteLine();

            // Sedelantal
            if (tillbaka >= 500)
            {
                Console.WriteLine("500-lappar     : {0}", (tillbaka / 500));
                tillbaka %= 500; 
            }
            if (tillbaka >= 100)
            {
                Console.WriteLine("100-lappar     : {0}", (tillbaka / 100));
                tillbaka %= 100; 
            }
            if (tillbaka >= 50)
            {
                Console.WriteLine(" 50-lappar     : {0}", (tillbaka / 50));
                tillbaka %= 50; 
            }
            if (tillbaka >= 20)
            {
                Console.WriteLine(" 20-lappar     : {0}", (tillbaka / 20));
                tillbaka %= 20; 
            }
            if (tillbaka >= 10)
            {
                Console.WriteLine(" 10-kronor     : {0}", (tillbaka / 10));
                tillbaka %= 10; 
            }
            if (tillbaka >= 5)
            {
                Console.WriteLine("  5-kronor     : {0}", (tillbaka / 5));
                tillbaka %= 5; 
            }
            if (tillbaka >= 1)
            {
                Console.WriteLine("  1-kronor     : {0}", tillbaka); 
            }
          
            // Avslut.
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Välkommen åter! Valfri knapp avslutar programmet.");
            Console.ReadKey();

        }
    }
}
