using System;
using System.Collections.Generic;
using System.Text;

namespace Graaf
{
    class Segment
    {
        //variabelen
        public Knoop beginKnoop { get; set; }
        public Knoop eindKnoop { get; set; }
        public int segmentID { get; set; }

        public List<Punt> vertices { get; set; }
        public int linksID { get; set; }
        public int rechtsID { get; set; }


        //constructor
        public Segment(int segmentID, Knoop beginKnoop, Knoop eindKnoop, List<Punt> vertices, int linksID, int rechtsID)
        {
            (this.segmentID, this.beginKnoop, this.eindKnoop, this.vertices, this.linksID, this.rechtsID) = (segmentID, beginKnoop, eindKnoop, vertices, linksID, rechtsID);
        }


        //functions
        /*public override Boolean Equals(object)
        {

            Boolean uitkomst = false;
            return uitkomst;
        }*/

        public override int GetHashCode()
        {
            int hashCode = 1;
            return hashCode;
        }

        public override string ToString()
        {
            return $"id: {segmentID}\n1e punt:\n{vertices[0].ToString()}\n2e punt:\n{vertices[1].ToString()}\n\n";
        }

        public string ToString2(Dictionary<int, String> strnlijst)
        {
            String uitkomst = $"SEGMENT samenvatting \n begin knoop id: {beginKnoop.knoopId}, eind knoop id: {eindKnoop.knoopId}, segment id: {segmentID}" +
                $"\n links id: {linksID} {strnlijst[linksID]}, rechts id: {rechtsID} {strnlijst[rechtsID]}";
            int counter = 1;
            foreach(Punt p in vertices)
            {
                uitkomst += $"\n #{counter.ToString()} x: {p.x}, y: {p.y}";
                counter++;
            }
            uitkomst += $"\n--------------------\n";

            return uitkomst;
        }

        public String ToString3(String naam)
        {
            return naam;
        }

    }
}
