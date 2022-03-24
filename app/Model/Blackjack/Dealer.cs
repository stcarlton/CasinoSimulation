namespace CasinoSimulation.Model.Blackjack
{
    public class Dealer : IPlayer
    {
        public Hand CurrentHand { get; set; }
        public bool Resolved { get; set; }
        public Dealer()
        {
            CurrentHand = null;
            Resolved = false;
        }

        public void DealIn(long bet)
        {
            Resolved = false;
            CurrentHand = new DealerHand();
        }
        public void Hit(Card c)
        {
            CurrentHand.ReceiveCard(c);
            if(!((DealerHand)CurrentHand).UnderSeventeen)
            {
                Stand();
            }
            else if(CurrentHand.State == handState.Bust)
            {
                Stand();
            }
        }
        public void Stand()
        {
            Resolved = true;
        }
    }
}
