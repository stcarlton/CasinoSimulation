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
                return Nick.CurrentHand?.Cards[1].Rank == cardRank.Ace && bet <= _user.Bankroll && ((Human)Raymond).InsuranceBet == 0;
            }
        }
        private List<IPlayer> _players { get; }
        private Deck _shoe { get; }
        private User _user { get; }

        public Table(User user)
        {
            TableState = 0;
            Nick = new Dealer();
            Raymond = new Human(user);
            _players = new List<IPlayer>();
            _shoe = new Deck(user.NumDecks);
            _players.Add(Raymond);
            _players.Add(Nick);
            _user = user;
        }

        public void Deal(long bet)
        {
            TableState = tableState.option;
            foreach(IPlayer p in _players)
            {
                p.DealIn(bet);
                p.Hit(_shoe.DealTopCard());
            }
            foreach (IPlayer p in _players)
            {
                p.Hit(_shoe.DealTopCard());
            }
            CheckTable();
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
        public void SplitPlayer(Human h)
        {
            h.Split(_shoe.DealTopCard(), _shoe.DealTopCard());
            CheckTable();
        }
        private void CheckTable()
        {
            if (((Human)Raymond).UnresolvedHands.Count == 0)
            {
                ResolveTable();
            }
        }
        private void ResolveTable()
        {
            TableState = tableState.settlement;
            ResolveDealer();
            ResolvePlayer((Human)Raymond);
            _shoe.Shuffle();
        }
        private void ResolveDealer()
        {
            while(!((Dealer)Nick).Resolved)
            {
                Nick.Hit(_shoe.DealTopCard());
            }
        }
        private void ResolvePlayer(Human c)
        {
            Hand d = Nick.CurrentHand;
            foreach (HumanHand h in c.ResolvedHands)
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
                switch (h.State)
                {
                    case handState.BlackJack: h.Winnings += h.Bet * 3; break;
                    case handState.Win: h.Winnings += h.Bet * 2; break;
                    case handState.Push: h.Winnings += h.Bet; break;
                    default: break;
                }
            }
        }
        public void SettleHand(Human c)
        {
            _user.Bankroll += ((HumanHand)c.CurrentHand).Winnings;
            c.ResolvedHands.Pop();
            if (((Human)Raymond).ResolvedHands.Count == 0)
            {
                TableState = tableState.betting;
            }
            else
            {
                c.CurrentHand = c.ResolvedHands.Peek();
            }
        }
    }
}
