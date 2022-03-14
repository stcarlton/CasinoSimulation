using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace CasinoSimulation.Model.Blackjack
{
    public struct Card
    {        
        public readonly cardRank Rank;
        public readonly cardSuit Suit;
        public readonly int CardValue;

        public Uri ImageUri { get; set; }
        public BitmapImage ImageData { get; set; }

        public Card(cardRank rank, cardSuit suit)
        {

            //"C:\\Users\\scarl\\Source\\Repos\\WPF_BlackJack\\WPF_BlackJack\\bin\\Debug\\\\Presentation\\Sounds\\BackgroundMusic\\BackgroundMusic.wav"
            //"C:\\Users\\scarl\\Source\\Repos\\CasinoSimulation\\app\\bin\\Debug\\netcoreapp3.1\\View\\Images\\Blackjack\\cards\\"
            Rank = rank;
            Suit = suit;
            string test = "C:\\Users\\scarl\\Source\\Repos\\CasinoSimulation\\app\\View\\Images\\Blackjack\\cards\\Ace_of_Spades.jpg";
            ImageUri = new Uri(test);
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\View\\Images\\Blackjack\\cards\\";
            //ImageUri = new Uri(path + rank + "_of_" + suit + ".jpg");
            ImageData = new BitmapImage(ImageUri);

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
