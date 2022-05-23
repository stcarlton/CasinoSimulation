using System.Collections.Generic;

namespace CasinoSimulation.Model.Blackjack
{
    /// <summary>
    /// abstract definitions shared by all hands
    /// (Requirement 1.2.2)
    /// </summary>
    public abstract class Hand
    {
        public List<Card> Cards { get; }
        public handState State { get; set; }
        //defines hand value
        //(Requirement 1.2.2)
        public int HandValue
        {
            get
            {
                int i = 0;
                bool hasAce = false;
                _soft = false;
                foreach (Card c in Cards)
                {
                    i += c.CardValue;
                    if (c.Rank == cardRank.Ace)
                    {
                        hasAce = true;
                    }
                }
                if (i <= 11 && hasAce)
                {
                    i += 10;
                    _soft = true;
                }
                return i;
            }
        }
        protected bool _soft;

        public Hand()
        {
            Cards = new List<Card>();
            _soft = false;
        }
        //receives card into hand and defines state of hand
        //(Requirement 1.2.2)
        public void ReceiveCard(Card c)
        {
            Cards.Add(c);
            if (HandValue == 21 && Cards.Count == 2)
            {
                State = handState.BlackJack;
            }
            else if (HandValue > 21)
            {
                State = handState.Bust;
            }
            else
            {
                State = handState.Unresolved;
            }
        }
    }
}
