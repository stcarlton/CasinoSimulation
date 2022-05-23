using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoSimulation.Model.Roulette
{
    /// <summary>
    /// (Requirement 1.2.3)
    /// </summary>
    public class Wheel
    {
        Random r = new Random();
        public int[] intArray = new int[] { 0, 26, 3, 35, 12, 28, 7, 29, 18, 22, 9, 31, 14, 20, 1, 33, 16, 24, 5, 10, 23, 8, 30, 11, 36, 13, 27, 6, 34, 17, 25, 2, 21, 4, 19, 15, 32 }; //the order is corresponds with wheel
        public int i; // can be used to find if its black or red.
        public double degree;
        public int number;
        //for future use otherwise simple class
        public Wheel()
        {

        }
        public void getNumber()
        {
            //*
            //change i to alternate value for testing
            //*//
            i = r.Next(0, 37);
            //i = 1;
            degree = i * 9.72972972973; //degree found for acurate spin degree
            number = intArray[i];
        }
    }
}
