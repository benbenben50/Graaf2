using System;
using System.Collections.Generic;
using System.Text;

namespace Graaf
{
    class Punt
    {
        //variabelen
        public Double x { get; set; }
        public Double y { get; set; }


        //constructor
        public Punt(Double x, Double y)
        {
            (this.x, this.y) = (x, y);
        }

        //functies
        /*public override Boolean Equals(object)
        {
            Boolean uitkomst = false;
            return uitkomst;
        }*/

        public override int GetHashCode()
        {
            return 1;
        }

        public override string ToString()
        {
            return $"x: {x} \n y: {y}";
        }
    }
}
