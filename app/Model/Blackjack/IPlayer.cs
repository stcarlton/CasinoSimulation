namespace CasinoSimulation.Model.Blackjack
{
    public interface IPlayer
    {
        public Hand CurrentHand { get; set; }

        public abstract void Stand();
        public abstract void Hit(Card c);
        public abstract void DealIn(long bet);
    }
}
