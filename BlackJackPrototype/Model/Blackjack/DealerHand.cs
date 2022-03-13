namespace CasinoSimulation.Model.Blackjack
{
    public class DealerHand : Hand
    {
        public bool UnderSeventeen
        {
            get
            {
                return HandValue < 17;
            }
        }
        public DealerHand() : base()
        {

        }
    }
}
