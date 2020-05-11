using System;
using System.Collections.Generic;
using System.Text;

namespace Graaf
{
    class Knoop
    {
        //variabelen
        public int knoopId;
        public Punt punt;

        //constructor
        public Knoop(int knoopId, Punt punt)
        {
            this.knoopId = knoopId;
            this.punt = punt;
        }

        //functies
        /*public override Boolean Equals(object)
        {
            Boolean uitkomst = false;
            return uitkomst;
        }*/

        public override int GetHashCode()
        {
            int hashCode = 0;
            return hashCode;

        }
        public override string ToString()
        {
            return $"knoopID: {knoopId}, punten: \n {punt.ToString()}";
        }
    }
}
