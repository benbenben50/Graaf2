using System;
using System.Collections.Generic;
using System.Text;

namespace Graaf
{
    class Segment
    {
        //variabelen
        public Knoop beginKnoop;
        public Knoop eindKnoop;
        public int segmentID;
        public List<Punt> vertices;

        //constructor
        public Segment(int segmentID, Knoop beginKnoop, Knoop eindKnoop, List<Punt> vertices)
        {
            this.segmentID = segmentID;
            this.beginKnoop = beginKnoop;
            this.eindKnoop = eindKnoop;
            this.vertices = vertices;
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
            String stringUitkomst = "begin id: " + beginKnoop.knoopId + ", eind id: " + eindKnoop.knoopId+", segment id: " + segmentID;
            return stringUitkomst;
        }

    }
}
