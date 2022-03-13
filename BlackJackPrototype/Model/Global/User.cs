using System;

namespace CasinoSimulation.Model.Global
{
    public class User
    {
        public long Bankroll { get; set; }
        public String Name;
        
        //configuration settings
        public int NumDecks { get; set; }
        
        public User(long bankroll)
        {
            this.Bankroll = bankroll;
            //default 6
            this.NumDecks = 6;
        }
    }
}
