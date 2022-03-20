using System;
using System.Collections.Generic;

namespace CasinoSimulation.Model.Global
{
    public class User
    {
        public long Bankroll { get; set; }
        public String Name;

        //configuration settings
        public stakes UserStakes { get; set; }
        public int NumDecks { get; set; }
        public int[] ChipDenominations { get; set; }
        public int[] BetRange { get; set; }
        public int MinBet { get; set; }
        public int MaxBet { get; set; }

        public User(long bankroll)
        {
            Bankroll = bankroll;
            NumDecks = 6;
            UserStakes = (stakes)10;
            MinBet = (int)UserStakes;
            MaxBet = (int)UserStakes * 100;
            ChipDenominations = new int[] { 10000, 5000, 2000, 1000, 500, 250, 100, 25, 10, 5, 1 };
        }
    }
}
