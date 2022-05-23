namespace CasinoSimulation.Model.Blackjack
{
    /// <summary>
    /// Defines the state of a hand
    /// (Requirement 1.2.2)
    /// </summary>
    public enum handState
    {
        Unresolved,
        Resolved,
        BlackJack,
        Bust,
        Win,
        Push,
        Lose
    }
}
