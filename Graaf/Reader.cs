using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Graaf
{
    class Reader
    {
        //functions
        public static List<String> FileSplitter(string fileToReadPath)/*file lezen*/
        {
            List<String> splittedLines = new List<String>();
            using (FileStream fs = File.Open(fileToReadPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    splittedLines.Add(s);
                }
            }
            return splittedLines;
        }

        public static List<String> Lijnsplitter(String lijn)/*bestand splitten per lijn (segment)*/
        {
            List<String> uitkomst = null;

            uitkomst = lijn.Split(";").ToList();

            return uitkomst;
        }

        public static List<String> InLijnSplitter(List<String> gesplitsteLijn)/*split alle lijnen in coördinaten*/
        {
            List<String> uitkomst = null;

            //onnodige tekens verwijderen
            gesplitsteLijn[1] = gesplitsteLijn[1].Replace("(", String.Empty).Replace(")", String.Empty);

            //splitst string in een lijst met de coördinaten, en verwijdert daarna de eerste lijn (hij splitst ze op per punt)
            uitkomst = gesplitsteLijn[1].Split(",").ToList();
            uitkomst.RemoveAt(0);

            return uitkomst;
        }

        public static List<Knoop> inLijnKnopenSplitter(List<String> lijstknopen) /*split knopen*/
        {
            List<Knoop> knopenLijst = new List<Knoop>();

            int idMaker = 0;
            foreach (String s in lijstknopen)
            {
                List<string> punten = s.Split(" ").ToList();
                Punt punt1 = new Punt(Double.Parse(punten[1]), Double.Parse(punten[2]));

                Knoop testSegKnoop1 = new Knoop(idMaker, punt1);
                knopenLijst.Add(testSegKnoop1);
                idMaker++;
            }

            return knopenLijst;
        }

        public static Segment maakSegment(List<String> gesplitsteLijn)/*steekt een lijn in een segment-object*/
        {
            Segment nu = null;



            return nu;
        }
    }
}
