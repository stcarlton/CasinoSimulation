using System.Collections.Generic;

namespace CasinoSimulation.Model.Blackjack
{
    public class HandDisplay
    {
        public List<Card> Cards;

        public HandDisplay(IPlayer p)
        {
            Cards = new List<Card>();
            
            if (p.CurrentHand != null)
            {
                foreach (Card c in p.CurrentHand.Cards)
                {
                    Cards.Add(c);
                }
            }
        }
    }
}
