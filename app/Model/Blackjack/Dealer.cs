namespace CasinoSimulation.Model.Blackjack
{
    /// <summary>
    /// Defines dealer data and functions
    /// (Requirement 1.2.2)
    /// </summary>
    public class Dealer : IPlayer
    {
        public Hand CurrentHand { get; set; }
        public bool Resolved { get; set; }
        public Dealer()
        {
            CurrentHand = null;
            Resolved = false;
        }

        //Initializes deal
        //(Requirement 3.2.2.2)
        public void DealIn(long bet)
        {
            Resolved = false;
            CurrentHand = new DealerHand();
        }
        //Defines dealer receiving card and stands if over 16
        //(Requirement 3.2.2.4)
        public void Hit(Card c)
        {
            CurrentHand.ReceiveCard(c);
            if (!((DealerHand)CurrentHand).UnderSeventeen)
            {
                Stand();
            }
        }
        //Defines dealer standing
        //(Requirement 3.2.2.5)
        public void Stand()
        {
            Resolved = true;
        }
    }
}
