using System;
using System.Collections.Generic;

namespace Graaf
{
    class Program
    {
        static void Main(string[] args)
        {
            //path naar bestand invullen
            String pathAlgemeen = @"C:\Users\Ben\Documents\school\prog3\WRdata.csv";
            String pathStraten = @"C:\Users\Ben\Documents\school\prog3\WRstraatnamen.csv";
            String pathGemeente = @"C:\Users\Ben\Documents\school\prog3\WRGemeentenaam.csv";
            //domeincontroller aanmaken
            Domeincontroller dc = new Domeincontroller(pathAlgemeen, pathStraten, pathGemeente);

            
            //keuzemenu
            int input;
            Boolean verder = true;
            do
            {
                Console.Write($"---------------\n0: sluiten\n1: toon straten\n2: toon gemeentes" +
                    $"\n3: toon segmenten\n4: geef segmenten met straatnaam:\n---------------\n");
                input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 0:
                        Console.WriteLine("Sluiten");
                        verder = false;
                        break;
                    case 1:
                        Console.Write($"---------------\n\n{dc.MenuStraten()}\n ---------------\n");
                        break;
                    case 2:
                        Console.Write(dc.MenuGemeentes());
                        break;
                    case 3:
                        Console.Write(dc.MenuSegmenten());
                        break;
                    case 4:
                        Console.Write(dc.MenuSegmentenMetNaam());
                        break;
                    default:
                        Console.WriteLine("Verkeerd");
                        break;
                }
            } while (verder == true);
            Environment.Exit(0);
        }
    }
}
