using System.Reflection;
using System.Resources;

/// <summary>
/// Defines card data
/// (Requirement 1.2.2)
/// </summary>
namespace CasinoSimulation.Model.Blackjack
{
    public struct Card
    {
        public readonly cardRank Rank;
        public readonly cardSuit Suit;
        public readonly int CardValue;
        public byte[] ImageData { get; }
        private ResourceManager _rm;

        public Card(cardRank rank, cardSuit suit)
        {
            Rank = rank;
            Suit = suit;
            _rm = new ResourceManager("CasinoSimulation.Properties.Resources", Assembly.GetExecutingAssembly());
            ImageData = (byte[])_rm.GetObject(Rank + "_of_" + Suit);

            //defines card value based on rank
            //(Requirement 1.2.2)
            switch (rank)
            {
                case cardRank.Jack:
                case cardRank.Queen:
                case cardRank.King: CardValue = 10; break;
                default: CardValue = (int)rank + 1; break;
            }
        }
        public Card(string s)
        {
            Rank = 0;
            Suit = 0;
            CardValue = 0;
            _rm = new ResourceManager("CasinoSimulation.Properties.Resources", Assembly.GetExecutingAssembly());
            ImageData = (byte[])_rm.GetObject(s);
        }
    }
}
