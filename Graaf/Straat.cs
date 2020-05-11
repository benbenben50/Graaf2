using System;
using System.Collections.Generic;
using System.Text;

namespace Graaf
{
    class Straat
    {
        //variabelen
        public GraafAlg graaf;
        public int straatID;
        public String straatNaam;

        //constructor
        public Straat(int straatID, String straatNaam, GraafAlg graaf)
        {
            this.straatID = straatID;
            this.straatNaam = straatNaam;
            this.graaf = graaf;
        }

        //functies
        public List<Knoop> GetKnopen()
        {
            List<Knoop> knopen = null;
            return knopen;
        }
    
        public void ShowStraat()
        {

        }
    }
}
