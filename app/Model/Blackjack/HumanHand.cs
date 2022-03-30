namespace CasinoSimulation.Model.Blackjack
{
    public class HumanHand : Hand
    {
        public long Bet { get; set; }
        public long Winnings { get; set; }
        public bool DoubleDownEligible
        {
            get
            {
                int k = HandValue;
                return Cards.Count == 2 && (k == 9 || k == 10 || k == 11 || (_soft && k > 18));
            }
        }

        public bool SplitEligible
        {
            get
            {
                return Cards.Count == 2 && Cards[0].Rank == Cards[1].Rank;
            }
        }
        public bool TwoAces
        {
            get
            {
                return Cards.Count == 2 && Cards[0].Rank == cardRank.Ace && Cards[1].Rank == cardRank.Ace;
            }
        }

        public HumanHand(long bet) : base()
        {
            Bet = bet;
            Winnings = 0;
        }
        public Card TakeCard()
        {
            Card _retCard = Cards[0];
            Cards.RemoveAt(0);
            return _retCard;
        }
        public void SetWinnings()
        {
            switch (State)
            {
                case handState.BlackJack: Winnings += Bet * 3; break;
                case handState.Win: Winnings += Bet * 2; break;
                case handState.Push: Winnings += Bet; break;
                default: break;
            }
        }
    }
}
