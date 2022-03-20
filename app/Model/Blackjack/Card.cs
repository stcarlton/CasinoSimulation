using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;


namespace CasinoSimulation.Model.Blackjack
{
    public struct Card
    {        
        public readonly cardRank Rank;
        public readonly cardSuit Suit;
        public readonly int CardValue;
        private ResourceManager _rm;
        public byte[] ImageData { get; set; }

        public Card(cardRank rank, cardSuit suit)
        {
            Rank = rank;
            Suit = suit;
            _rm = new ResourceManager("CasinoSimulation.Properties.Resources", Assembly.GetExecutingAssembly());
            ImageData = (byte[])_rm.GetObject(Rank + "_of_" + Suit);

            switch (rank)
            {
                case cardRank.Jack:
                case cardRank.Queen:
                case cardRank.King: CardValue = 10; break;
                default: CardValue = (int)rank + 1; break;
            }
        }
    }
}
