using System;
using System.Collections.Generic;
using System.Text;

namespace Graaf
{
    class Punt
    {
        //variabelen
        public Double x;
        public Double y;

        //constructor
        public Punt(Double x, Double y)
        {
            this.x = x;
            this.y = y;
        }

        //functies
        /*public override Boolean Equals(object)
        {
            Boolean uitkomst = false;
            return uitkomst;
        }*/

        public override int GetHashCode()
        {
            int uitkomst = 1;
            return uitkomst;
        }

        public override string ToString()
        {
            String uitkomst = "hallo";
            return uitkomst;
        }
    }
}
