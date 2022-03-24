using System.Collections.Generic;

namespace CasinoSimulation.Model.Blackjack
{
    public abstract class Hand
    {
        public List<Card> Cards { get; }
        public handState State { get; set; }
        public int HandValue
        {
            get
            {
                int i = 0;
                foreach (Card c in Cards)
                {
                    i += c.CardValue;
                }
                if (i <= 11 && _hasAce)
                {
                    i += 10;
                }
                return i;
            }
        }
        protected bool _hasAce
        {
            get
            {
                foreach(Card c in Cards)
                {
                    if (c.Rank == cardRank.Ace) return true;
                }
                return false;
            }
        }

        public Hand()
        {
            Cards = new List<Card>();
        }
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
