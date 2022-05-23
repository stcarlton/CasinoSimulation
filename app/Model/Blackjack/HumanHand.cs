namespace CasinoSimulation.Model.Blackjack
{
    /// <summary>
    /// Defines player hand
    /// (Requirement 1.2.2)
    /// </summary>
    public class HumanHand : Hand
    {
        public long Bet { get; set; }
        public long Winnings { get; set; }
        //Check if hand is eligible to double down
        //(Requirement 3.2.1.2.3)
        public bool DoubleDownEligible
        {
            get
            {
                int k = HandValue;
                return Cards.Count == 2 && (k == 9 || k == 10 || k == 11 || (_soft && k > 18));
            }
        }
        //Check if hand is eligible to split
        //(Requirement 3.2.1.2.4)

        public bool SplitEligible
        {
            get
            {
                return Cards.Count == 2 && Cards[0].Rank == Cards[1].Rank;
            }
        }

        public HumanHand(long bet) : base()
        {
            Bet = bet;
            Winnings = 0;
        }
        //Remove card during split
        //(Requirement 3.2.2.7)
        public Card TakeCard()
        {
            Card _retCard = Cards[0];
            Cards.RemoveAt(0);
            return _retCard;
        }
        //Pay out hand during settlement
        //(Requirement 3.2.1.3)
        public void SetWinnings()
        {
            switch (State)
            {
                case handState.BlackJack: Winnings += (long)(Bet * 2.5); break;
                case handState.Win: Winnings += Bet * 2; break;
                case handState.Push: Winnings += Bet; break;
                default: break;
            }
        }
    }
}
