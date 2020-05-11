using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Graaf
{
    class Domeincontroller
    {
        //variabelen
        public List<Segment> segmenten { get; set; }
        public Dictionary<int, List<Segment>> straatLijst = new Dictionary<int, List<Segment>>();
        public Dictionary<int, String> straatNaamLijst;
        public List<Dictionary<int, List<String>>> gemeenteLijst;

        //Constructor
        public Domeincontroller(String url, String straatUrl, String gemeenteUrl)/*constructor*/
        {
            segmenten = new List<Segment>();
            VulSegmentenLijstIn(url);
            VulDictionaryIn();
            vulStraatDictionaryIn(straatUrl);
            vulGemeentesIn(gemeenteUrl);
        }


        //vulfuncties
        private void VulSegmentenLijstIn(String url) /*lijst van segmenten inlezen uit bestand (met url)*/
        {
            List<String> gelezenBestand = Reader.FileSplitter(url);
            foreach (String g in gelezenBestand.Skip(1))
            {
                List<String> tijdelijkeLijn = Reader.Lijnsplitter(g);
                Segment s = Reader.maakSegment(tijdelijkeLijn);
                segmenten.Add(s);
            }
        }

        private void VulDictionaryIn()/*vult dictionary met de straten*/
        {
            foreach(Segment s in segmenten)
            {
                //segmenten in straten steken aan de Rechterkant
                if (straatLijst.ContainsKey(s.rechtsID))
                {
                    straatLijst[s.rechtsID].Add(s);
                }
                else
                {
                    straatLijst.Add(s.rechtsID, new List<Segment> { s });
                }

                //segmenten in straten steken aan de Linkerkant
                if (straatLijst.ContainsKey(s.linksID))
                {
                    straatLijst[s.linksID].Add(s);
                }
                else
                {
                    straatLijst.Add(s.rechtsID, new List<Segment> { s });
                }

            }
        }

        private void vulStraatDictionaryIn(String straatUrl)
        {
            straatNaamLijst = Reader.inLijnSplitterStraat(Reader.FileSplitterStraten(straatUrl));
        }

        private void vulGemeentesIn(String gemeenteUrl){
            gemeenteLijst = Reader.InLijnSplitterGemeente(Reader.FileSplitterGemeente(gemeenteUrl));
        }


        //display functions
        public String DisplayAlleSegmenten() /*alle segmenten printen in een String*/
        {
            String uitkomst ="";
            int i = 1;

            foreach (Segment st in segmenten)
            {
                uitkomst += $"i: {i.ToString()}, {st.ToString()}\n";
                i++;
            }
            uitkomst += $"\n\n\n\n";

            return uitkomst;
        }

        public String DisplayXAantalSegmenten(int aantal){
            String uitkomst = "";
            int i = 1;

            foreach(Segment s in segmenten.Take(aantal)){
                uitkomst += $"i: {i.ToString()}, {s.ToString2(straatNaamLijst)}\n";
                i++;
            }
            return uitkomst;
        }

        public String DisplayGegevensSegmenten()/*gegevens van het aantal segmenten printen*/
        {
            return $"Gegevens segmenten \n --------------- \naantal: {segmenten.Count().ToString()}";
        }

        public String DisplayVerschillendeStratenSimpel()/*display alle straten met aantal in string*/
        {
            String uitkomst = "";

            //één voor één straten in een string steken
            int i = 1;
            foreach (KeyValuePair<int, List<Segment>> key in straatLijst)
            {
                uitkomst += $"{i.ToString()}\nStraatID: {key.Key.ToString()}\n";
                foreach(Segment s in key.Value)
                {
                    uitkomst += $"SegmentID: {s.segmentID}, aantal punten: {s.vertices.Count()}\n";
                }
                uitkomst += $"------------\n\n";
                i++;
            }

            return uitkomst;
        }

        public String DisplayVerschillendeStraten()/*zelfde als Simpele versie maar hier met alle info (zwaarder om te runnen)*/
        {
            String uitkomst = "";

            //één voor één straten in een string steken
            foreach (KeyValuePair<int, List<Segment>> key in straatLijst)
            {
                uitkomst += $"StraatID: {key.Key.ToString()}\n";
                foreach (Segment s in key.Value)
                {
                    uitkomst += $"SegmentID: {s.segmentID}\nbeginKnoop: {s.beginKnoop.knoopId} x: {s.beginKnoop.punt.x}, y: {s.beginKnoop.punt.y}\n";
                    
                    int i = 1;
                    foreach(Punt p in s.vertices)
                    {
                        uitkomst += $"id: {i.ToString()}, x: {p.x}, y: {p.y}\n";
                        i++;
                    }
                }
                uitkomst += $"\n------------";
            }

            return uitkomst;
        }

        public String DisplayStraten(int aantal)/*eerste 50 straten displayen*/{
            String uitkomst = "";
            foreach (KeyValuePair<int, String> k in straatNaamLijst){
                uitkomst += $"id: {k.Key.ToString()}, sn: {k.Value}\n";
                if (k.Key.Equals(aantal)) {
                    break;
                }
            }


            return uitkomst;
        }

        public String DisplayGemeentes()/*alle gemeentes displayen*/{
            String uitkomst ="";
            String previous = "-1";
            foreach (Dictionary<int, List<String>> k in gemeenteLijst)
            {                
                foreach(KeyValuePair<int, List<String>> l in k)
                {
                    if(previous == l.Value[0]){
                        uitkomst += $"{l.Value[1]}: {l.Value[2]}\n";
                    }
                    else{
                        uitkomst += "\ngemeenteId: " + l.Key + "\n";
                        uitkomst += $"{l.Value[1]}: {l.Value[2]}\n";
                    }
                    
                    previous = l.Value[0];
                }
            }
            return uitkomst;
        }

        public String DisplayGemeentesAantal(int aantal)/*display x aantal gemeentes*/{
            int teller = 0;
            String uitkomst = "";
            String previous = "-1";
            foreach (Dictionary<int, List<String>> k in gemeenteLijst)
            {
                if(teller == aantal){
                    break;
                }
                else { 
                    foreach (KeyValuePair<int, List<String>> l in k){
                        if (previous == l.Value[0]){
                            uitkomst += $"{l.Value[1]}: {l.Value[2]}\n";
                        }
                        else{
                            uitkomst += "\ngemeenteId: " + l.Key + "\n";
                            uitkomst += $"{l.Value[1]}: {l.Value[2]}\n";
                            teller++;
                        }
                        previous = l.Value[0];
                    }
                }
            }
            return uitkomst;
        }

        public String DisplaySegmentenMetSN(String straatNaam){
            int myKey = straatNaamLijst.FirstOrDefault(x => x.Value == straatNaam).Key;
            String uitkomst = "";

            List<Segment> nu = new List<Segment>();
            foreach(Segment s in segmenten){
                if(s.linksID == myKey || s.rechtsID == myKey){
                    nu.Add(s);
                    uitkomst += $"{s.segmentID}, ";
                }
            }
            return uitkomst;
        }


        //alle menu-elementen (uitprinten)
        public String MenuStraten()/*menu voor straten (x aantal gemeentes aanroepen*/{
            Console.WriteLine("\n\n---------------\nHoeveel straten zou je willen zien?\n---------------\n");
            int aantal  = int.Parse(Console.ReadLine());
            return DisplayStraten(aantal);
        }

        public String MenuGemeentes()/*menu voor gemeentes*/{
            Console.WriteLine("\n\n---------------\nHoeveel gemeentes zou je willen zien (-1 is alle)?\n---------------\n");
            String aantal = Console.ReadLine();
            if(aantal == "-1"){
                return DisplayGemeentes();
            }
            else if(Regex.IsMatch(aantal, @"^\d+$") == true){
                return DisplayGemeentesAantal(Int32.Parse(aantal));
            }
            else{
                return "Geef een juiste waarde in!\n\n";
            }
        }

        public String MenuSegmenten()/*menu voor segmenten*/{
            Console.WriteLine("\n\n---------------\nHoeveel segmenten zou je willen zien?\n---------------\n");
            int aantal = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");
            if(aantal == -1){
                return DisplayAlleSegmenten();
            }
            else if(0 < aantal && segmenten.Count() > aantal){
                return DisplayXAantalSegmenten(aantal);
            }
            else{
                return "Verkeerd.";
            }
        }
        
        public String MenuSegmentenMetNaam(){
            String uitkomst = "";
            Console.WriteLine("\n---------------\nVan welke straatnaam wil je de segmenten?\n");
            String straatNaam = Console.ReadLine();
            int straatNaamId = getIdStraatNaam(straatNaam);

           foreach(Segment s in segmenten){
                if (s.linksID == straatNaamId || s.rechtsID == straatNaamId) {
                    uitkomst += $"\n{s.ToString()}\n";
                }
           }

            return uitkomst;
        }



        //rest
        private int getIdStraatNaam(String straatnaam){
            return straatNaamLijst.FirstOrDefault(x => x.Value == straatnaam).Key;
        }
        
    }
}