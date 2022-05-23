namespace CasinoSimulation.Model.Blackjack
{
    /// <summary>
    /// Defines dealer hand
    /// (Requirement 1.2.2)
    /// </summary>
    public class DealerHand : Hand
    {
        //Check if dealer hand is under 17 or a soft 17
        //(Requirement 3.2.2.9)
        public bool UnderSeventeen
        {
            get
            {
                return HandValue < 17 || (HandValue == 17 && _soft);
            }
        }
        public DealerHand() : base()
        {

        }
    }
}
