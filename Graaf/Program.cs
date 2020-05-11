using System;
using System.Collections.Generic;

namespace Graaf
{
    class Program
    {
        static void Main(string[] args)
        {
            //bestand lezen
            String path = @"C:\Users\Ben\Documents\school\prog3\WRdata10.csv";
            List<String> result = Reader.FileSplitter(path);


            //printen van een straat waarvan alles gesplit is:
            List<String> lijn2Test = Reader.Lijnsplitter(result[0]); /*eerste lijn (titels)*/
            List<String> lijn1Test = Reader.Lijnsplitter(result[2]);        
            List<String> gesplitteLijn = Reader.InLijnSplitter(lijn1Test); /*splitten van een random lijn*/

            //split bovenstaande lijn en steek alle coördinaten in knoop-objecten
            List<Knoop> testknopen = Reader.inLijnKnopenSplitter(gesplitteLijn);

            //knopen lijst weergeven            
            foreach(Knoop k in testknopen)
            {
                Console.WriteLine(k.ToString());
            }
           

            /*testen van de lijn hierboven, met de titels ernaast
            Console.Write(lijn2Test[0] + ": " + lijn1Test[0] + "\n" + lijn2Test[1] + ": " + lijn1Test[1] + "\n" + lijn2Test[2] 
                + ": " + lijn1Test[2] + "\n" + lijn2Test[3] + ": " + lijn1Test[3] + "\n" + lijn2Test[4] + ": " + lijn1Test[4] + "\n" +
                lijn2Test[5] + ": " + lijn1Test[5] + "\n" + lijn2Test[6] + ": " + lijn1Test[6] + "\n" + lijn2Test[7] + ": " + lijn1Test[7]);
            */
            
        }
    }
}
