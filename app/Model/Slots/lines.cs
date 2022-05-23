using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoSimulation.Model.Slots
{
    /// <summary>
    ///  Holds location for three lines
    // (Requirement 1.2.4)
    /// </summary>
    public class lines
    {
        /*locations are how far each slt image should go down the y axis, 
         the numbers are the found to find were the cards should be*/
        int[] locations = new int[] { -2745, -3145, -3545, -3945, -4345, -4735, -5135 };
        public int line1;
        public int line2;
        public int line3;
        public lines()
        {

        }
    }
}
