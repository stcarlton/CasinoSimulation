namespace CasinoSimulation.Model.Blackjack
{
    public struct Card
    {        
        public readonly cardRank Rank;
        public readonly cardSuit Suit;
        public string Display { get; set; }
        public readonly int CardValue;
        public Card(cardRank rank, cardSuit suit)
        {
            this.Rank = rank;
            this.Suit = suit;
            Display = rank + " of " + suit;

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
