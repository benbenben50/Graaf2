using System;
using System.Collections.Generic;
using System.Text;

namespace Graaf
{
    class GraafAlg
    {
        //variabelen
        public int graafID;
        public Dictionary<Knoop, List<Segment>> map;
        public List<Knoop> knopen;
        

        //constructor
        GraafAlg(int id)
        {
            graafID = id;
        }

        //functions
        public List<Knoop> getKnopen()
        {
            return knopen;
        }



        public void showGraaf()
        {

        }
        
    }
}
