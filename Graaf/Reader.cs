using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Globalization;

namespace Graaf
{
    class Reader
    {
        //algemeen bestand lezen
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

        public static List<String> InLijnSplitter(List<String> gesplitsteLijn)/*split alle lijnen in coördinaten (punten), de rest split hij niet (bijvoorbeeld segent ID)*/
        {
            List<String> uitkomst = new List<String>();

            //onnodige tekens verwijderen
            gesplitsteLijn[1] = gesplitsteLijn[1].Replace("(", String.Empty).Replace(")", String.Empty);

            //splitst string in een lijst met de coördinaten, en verwijdert daarna de eerste lijn (hij splitst ze op per punt) (de eerste lijn is de Linestring)
            uitkomst = gesplitsteLijn[1].Split(",").ToList();
            uitkomst.RemoveAt(0);
            return uitkomst;
        }

        public static List<String> inLijnVolledigSplitter(List<String> gesplitsteLijn)/*doet alles wat hierboven niet gedaan wordt (inLijnSplitter)*/
        {
            List<String> uitkomst = new List<String>();

            //hier snel alles in variabelen steken, zodat ik het later in een object kan steken
            String wegSegmentID = gesplitsteLijn[0];
            String geo = gesplitsteLijn[1];
            String morfologie = gesplitsteLijn[2];
            String status = gesplitsteLijn[3];
            String beginWK = gesplitsteLijn[4];
            String eindWK = gesplitsteLijn[5];
            String linksSN = gesplitsteLijn[6];
            String rechtsSN = gesplitsteLijn[7];            

            //uitkomst invullen en returnen
            uitkomst.Add(wegSegmentID);
            uitkomst.Add(geo);
            uitkomst.Add(morfologie);
            uitkomst.Add(status);
            uitkomst.Add(beginWK);
            uitkomst.Add(eindWK);
            uitkomst.Add(linksSN);
            uitkomst.Add(rechtsSN);
            return uitkomst;
        }

        public static List<Knoop> inLijnKnopenSplitter(List<String> lijstknopen) /*split knopen, moet enkel voor eerste een laatste van segment*/
        {
            List<Knoop> knopenLijst = new List<Knoop>();

            int idMaker = 0;
            foreach (String s in lijstknopen)
            {
                List<string> punten = s.Split(" ").ToList();    
                Punt punt1 = new Punt(Double.Parse(punten[1], CultureInfo.InvariantCulture), Double.Parse(punten[2], CultureInfo.InvariantCulture));
                Knoop testSegKnoop1 = new Knoop(idMaker, punt1);
                knopenLijst.Add(testSegKnoop1);
                idMaker++;
            }

            return knopenLijst;
        }

        public static Segment maakSegment(List<String> gesplitsteLijn)/*steekt een lijn in een segment-object*/
        {
            List<Knoop> knopen = inLijnKnopenSplitter(InLijnSplitter(gesplitsteLijn));
            List<Punt> punten = GeefPuntenVanLijn(gesplitsteLijn);
            List<String> eindResLijn = inLijnVolledigSplitter(gesplitsteLijn);

            Segment nu = new Segment(int.Parse(eindResLijn[0].ToString()), knopen.First(), 
                knopen.Last(), punten, int.Parse(eindResLijn[6]), int.Parse(eindResLijn[7]));
            return nu;
        }

        public static GraafAlg maakGraaf(List<Segment> segmenten)/*maakt een graaf object aan*/
        {
            GraafAlg graaf = null;
            Knoop k = null;
            //Dictionary<Knoop, List<Segment>> d = new Dictionary<Knoop, List<Segment>>;
            //d.Add(segmenten[0].beginKnoop, segmenten);


            return graaf;
        }

        public static List<Punt> GeefPuntenVanLijn(List<String> gesplitsteLijn)/*er wordt een lijn gegeven, en hiervan pakt hij de punten (zonder begin en eindpunt)*/
        {
            List<Punt> punten = new List<Punt>();
            List<String> lijstPuntenStrings = Reader.InLijnSplitter(gesplitsteLijn);
            lijstPuntenStrings.RemoveAt(lijstPuntenStrings.Count - 1);
            foreach (String s in lijstPuntenStrings.Skip(1))
            {
                List<string> puntenNu = s.Split(" ").ToList();
                Punt punt1 = new Punt(Double.Parse(puntenNu[1], CultureInfo.InvariantCulture), Double.Parse(puntenNu[2], CultureInfo.InvariantCulture));
                punten.Add(punt1);
            }


            return punten;
        }


        //straten bestand
        public static List<String> FileSplitterStraten(string fileToReadPath)/*file lezen*/
        {
            List<String> splittedLines = new List<String>();
            using (FileStream fs = File.Open(fileToReadPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    splittedLines.Add(s.Trim());
                }
            }
            splittedLines.RemoveAt(0);

            return splittedLines;
        }

        public static Dictionary<int, String> inLijnSplitterStraat(List<String> gesplitteFileStraten)
        {
            Dictionary<int, String> uitkomst = new Dictionary<int, string>();
            foreach(String s in gesplitteFileStraten)
            {
                List<String> lijst = new List<string>();
                lijst = s.Split(";").ToList();
                uitkomst.Add(int.Parse(lijst[0]), lijst[1]);
            }
            return uitkomst;
        }



        //gemeente bestand
        public static List<String> FileSplitterGemeente(string fileToReadPath)/*Split gemeente file*/
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
            splittedLines.RemoveAt(0);
            return splittedLines;
        }



        //Hier moet nog aan gewerkt worden!
        public static List<Dictionary<int, List<String>>> InLijnSplitterGemeente(List<String> gesplitteFileGemeente)
        {
            List<Dictionary<int, List<String>>> uitkomst = new List<Dictionary<int, List<String>>>();
            foreach(String s in gesplitteFileGemeente)
            {
                List<String> str = s.Split(";").ToList();
                Dictionary<int, List<String>> line = new Dictionary<int, List<string>>();
                List<String> strings = new List<string>();
                strings.Add(str[1]);
                strings.Add(str[2]);
                strings.Add(str[3]);


                line.Add(Int32.Parse(str[1]), strings);
                uitkomst.Add(line);
            }
            return uitkomst;
        }


        

        //test gemeentes
        public static List<Dictionary<int, List<List<String>>>> InLijnSplitterGemeente2(List<String> gesplitteFileGemeente)
        {
            List<Dictionary<int, List<List<String>>>> uitkomst = new List<Dictionary<int, List<List<String>>>>();
            String previous = "-1";
            Boolean first = true;
            List<List<String>> huidigeGemeente = new List<List<String>>();
            Dictionary<int, List<List<String>>> toevoegen = new Dictionary<int, List<List<string>>>();

            foreach (String s in gesplitteFileGemeente)
            {
                List<String> str = s.Split(";").ToList();
                Dictionary<int, List<String>> line = new Dictionary<int, List<string>>();
                List<String> strings = new List<string>();
                strings.Add(str[1]);
                strings.Add(str[2]);
                strings.Add(str[3]);

                if (previous == str[1] || first == true)
                {
                    first = false;
                    List<String> hier = new List<string>();
                    hier.Add(str[2]);
                    hier.Add(str[3]);
                    huidigeGemeente.Add(hier);
                }
                else
                {
                    toevoegen.Clear();
                    toevoegen.Add(Int32.Parse(str[1]), huidigeGemeente);
                    uitkomst.Add(toevoegen);
                    
                    huidigeGemeente.Clear();
                    List<String> hier2 = new List<string>();
                    hier2.Add(str[2]);
                    hier2.Add(str[3]);
                    huidigeGemeente.Add(hier2);
                }
                previous = str[1];
            }
            return uitkomst;

        }

    }
}
