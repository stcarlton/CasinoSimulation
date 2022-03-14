using System;

namespace CasinoSimulation.Model.Global
{
    public class User
    {
        public long Bankroll { get; set; }
        public String Name;
        
        //configuration settings
        public int NumDecks { get; set; }
        public int MinBet { get; set; }
        public int MaxBet { get; set; }
        
        public User(long bankroll)
        {
            Bankroll = bankroll;
            NumDecks = 6;
            MinBet = 1;
            MaxBet = 1000;
        }
    }
}
