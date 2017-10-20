using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts
{
    public class Darts
    {
        private Random chaosTheory;
        public int Zone { get; set; }
        public bool InnerRing { get; set; }
        public bool OuterRing { get; set; }



        public Darts(Random objRandom)
        {
            this.chaosTheory = objRandom;
        }

        public Darts()
        {
            //empty constructor
        }

        public void Throw()
        {
            //Make sure our booleans are set to false to start
            OuterRing = false;
            InnerRing = false;
            //Now, get zone. Zone 0 is the bullseye
            Zone = chaosTheory.Next(0, 20);
            //Compute ringage... note that if any single number has equal probabiliy
            //then ANY number between 1 and 20 has a 5 percent chance of making it.
            if (chaosTheory.Next(1, 20) == 5) OuterRing = true;  //rather than choose '1'
            if (chaosTheory.Next(1, 20) == 7) InnerRing = true;  //rather than reuse first choice.
            //for zone 0 (bullseye) the inner ring is alway false:
            //hitting the inner bullseye is just a matter of having zone 0 and outerring=false.
            if (Zone == 0) InnerRing = false;
        }









    }
}
