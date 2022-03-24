using System;
using System.Collections.Generic;

namespace CasinoSimulation.Model.Global
{
    public class User
    {
        public long Bankroll { get; set; }
        public stakes UserStakes
        {
            get
            {
                return _userStakes;
            }
            set
            {
                _userStakes = value;
                MinBet = ChipDenominations[(int)UserStakes];
                MaxBet = MinBet * 100;
            }
        }
        public String Name;
        public int NumDecks { get; set; }
        public int[] ChipDenominations { get; }
        public int MinBet { get; set; }
        public int MaxBet { get; set; }
        private stakes _userStakes;

        public User(long bankroll)
        {
            Bankroll = bankroll;
            NumDecks = 6;
            ChipDenominations = new int[] { 10000, 5000, 2000, 1000, 500, 250, 100, 25, 10, 5, 1 };
            UserStakes = (stakes)6;
        }
    }
}
