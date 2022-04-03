using System.Collections.Generic;
using CasinoSimulation.Model.Global;

namespace CasinoSimulation.Model.Blackjack
{
    public class Table
    {
        public tableState TableState { get; set; }
        public IPlayer Nick { get; }
        public IPlayer Raymond { get; }
        public bool InsuranceEligible
        {
            get
            {
                long bet = ((HumanHand)Raymond.CurrentHand)?.Bet < 2 ? 1 : ((HumanHand)Raymond.CurrentHand).Bet;
                if(Nick.CurrentHand?.Cards.Count < 2)
                {
                    return false;
                }
                else
                {
                    return Nick.CurrentHand?.Cards[1].Rank == cardRank.Ace && bet <= _user.Bankroll && ((Human)Raymond).InsuranceBet == 0;
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

        public void DealIn(long bet)
        {
            TableState = tableState.option;
            foreach(IPlayer p in Players)
            {
                p.DealIn(bet);
            }
        }
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
        public void StandPlayer(IPlayer p)
        {
            p.Stand();
            CheckTable();
        }
        public void HitPlayer(IPlayer p)
        {
            p.Hit(_shoe.DealTopCard());
            CheckTable();
        }
        public void DoubleDownPlayer(Human h)
        {
            h.DoubleDown(_shoe.DealTopCard());
            CheckTable();
        }
        public void SplitUpPlayer(Human h)
        {
            h.SplitUp();
        }
        public void DealSplitPlayer(Human h)
        {
            h.DealSplit(_shoe.DealTopCard(), _shoe.DealTopCard());
            CheckTable();
        }
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
        public void CheckTable()
        {
            if (Raymond.CurrentHand.State!=handState.Unresolved)
            {
                ResolveTable();
            }
        }
        private void ResolveTable()
        {
            TableState = tableState.settlement;
            ResolveDealer();
            ResolveHand(Nick.CurrentHand, (HumanHand)Raymond.CurrentHand);
            _shoe.Shuffle();
        }
        private void ResolveDealer()
        {
            while(!((Dealer)Nick).Resolved)
            {
                Nick.Hit(_shoe.DealTopCard());
            }
        }
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
