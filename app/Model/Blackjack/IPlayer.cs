namespace CasinoSimulation.Model.Blackjack
{
    /// <summary>
    /// interface for all players
    /// (Requirement 1.2.2)
    /// </summary>
    public interface IPlayer
    {
        public Hand CurrentHand { get; set; }

        public abstract void Stand();
        public abstract void Hit(Card c);
        public abstract void DealIn(long bet);
    }
}
