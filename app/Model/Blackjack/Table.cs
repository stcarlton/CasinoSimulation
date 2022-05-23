using System.Collections.Generic;
using CasinoSimulation.Model.Global;

namespace CasinoSimulation.Model.Blackjack
{
    /// <summary>
    /// Model component of MVVM architecture
    /// Container for all blackjack data models
    /// (Requirement 1.2.2)
    /// </summary>
    public class Table
    {
        public tableState TableState { get; set; }
        public IPlayer Nick { get; }
        public IPlayer Raymond { get; }
        //Defines if the player is eligible to buy insurance
        //(Requirement 3.2.1.2.5)
        public bool InsuranceEligible
        {
            get
            {
                long bet = ((HumanHand)Raymond.CurrentHand)?.Bet < 2 ? 1 : ((HumanHand)Raymond.CurrentHand).Bet;
                if (Nick.CurrentHand?.Cards.Count < 2)
                {
                    return false;
                }
                else
                {
                    return Nick.CurrentHand?.Cards[1].Rank == cardRank.Ace
                        && bet <= _user.Bankroll && ((Human)Raymond).InsuranceBet == 0
                        && Raymond.CurrentHand.Cards.Count == 2
                        && ((Human)Raymond).UnresolvedHands.Count < 1
                        && ((Human)Raymond).ResolvedHands.Count < 1;
                }
            }
        }
        public List<IPlayer> Players { get; }
        private Deck _shoe { get; }
        private User _user { get; }

        public Table(User user)
        {
            TableState = 0;
            Nick = new Dealer();
            Raymond = new Human(user);
            Players = new List<IPlayer>();
            _shoe = new Deck(user.NumDecks);
            Players.Add(Raymond);
            Players.Add(Nick);
            _user = user;
        }

        //Deals all players in and advances table state to option
        //(Requirement 3.2.1.1.2)
        public void DealIn(long bet)
        {
            TableState = tableState.option;
            foreach (IPlayer p in Players)
            {
                p.DealIn(bet);
            }
        }
        //Places insurance bet
        //(Requirement 3.2.1.2.3)
        public void PlaceInsuranceBet(long betValue)
        {
            ((Human)Raymond).InsuranceBet = betValue < 2 ? 1 : betValue / 2;
            _user.Bankroll -= ((Human)Raymond).InsuranceBet;
            if (Nick.CurrentHand.State == handState.BlackJack)
            {
                ((Human)Raymond).SettleInsurance();
                StandPlayer(Raymond);
            }
        }
        //Stands player and checks if all hands are resolved
        //(Requirement 3.2.2.5)
        public void StandPlayer(IPlayer p)
        {
            p.Stand();
            CheckTable();
        }
        //Hits player and checks if all hands are resolved
        //(Requirement 3.2.2.4)
        public void HitPlayer(IPlayer p)
        {
            p.Hit(_shoe.DealTopCard());
            CheckTable();
        }
        //Doubles down player and checks if all hands are resolved
        //(Requirement 3.2.2.6)
        public void DoubleDownPlayer(Human h)
        {
            h.DoubleDown(_shoe.DealTopCard());
            CheckTable();
        }
        //First half of splitting a hand
        //(Requirement 3.2.2.7)
        public void SplitUpPlayer(Human h)
        {
            h.SplitUp();
        }
        //Second half of splitting a hand
        //(Requirement 3.2.2.7)
        public void DealSplitPlayer(Human h)
        {
            h.DealSplit(_shoe.DealTopCard(), _shoe.DealTopCard());
            CheckTable();
        }
        //Settles payout for hand
        //(Requirement 3.2.1.2.3)
        public void SettleHand(Human c)
        {
            _user.Bankroll += ((HumanHand)c.CurrentHand).Winnings;
            if (((Human)Raymond).ResolvedHands.Count > 0)
            {
                c.CurrentHand = c.ResolvedHands.Pop();
                ResolveHand(Nick.CurrentHand, (HumanHand)Raymond.CurrentHand);
            }
            else
            {
                TableState = tableState.betting;
            }
        }
        //Checks if all hands are resolved
        //(Requirement 3.2.1.2)
        public void CheckTable()
        {
            if (Raymond.CurrentHand.State != handState.Unresolved && Nick.CurrentHand.Cards.Count > 1)
            {
                ResolveTable();
            }
        }
        //Advances table to final settlement state, resolves dealer and player
        //(Requirement 3.2.1.2)
        private void ResolveTable()
        {
            TableState = tableState.settlement;
            ResolveDealer();
            ResolveHand(Nick.CurrentHand, (HumanHand)Raymond.CurrentHand);
            _shoe.Shuffle();
        }
        //Resolves dealer
        //(Requirement 3.2.2.9)
        private void ResolveDealer()
        {
            while (!((Dealer)Nick).Resolved)
            {
                Nick.Hit(_shoe.DealTopCard());
            }
        }
        //Resolves the hand based on the states of the player and the dealer
        //pays out each hand accordingly
        //(Requirement 3.2.1.3)
        private void ResolveHand(Hand d, HumanHand h)
        {
            if (h.State == handState.BlackJack)
            {
                if (d.State == handState.BlackJack)
                {
                    h.State = handState.Push;
                }
            }
            else if (d.State == handState.BlackJack)
            {
                h.State = handState.Lose;
            }
            else if (h.State != handState.Bust)
            {
                if (d.State == handState.Bust)
                {
                    h.State = handState.Win;
                }
                else if (h.HandValue == d.HandValue)
                {
                    h.State = handState.Push;
                }
                else if (h.HandValue < d.HandValue)
                {
                    h.State = handState.Lose;
                }
                else
                {
                    h.State = handState.Win;
                }
            }
            h.SetWinnings();
        }
    }
}
