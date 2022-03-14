using System.Collections.Generic;
using CasinoSimulation.Model.Global;

namespace CasinoSimulation.Model.Blackjack
{
    public class Table
    {
        public IPlayer Nick { get; set; }
        public IPlayer Raymond { get; set; }
        public bool Resolved { get; set; }
        public bool InsuranceEligible
        {
            get
            {
                return Nick.CurrentHand.Cards[0].Rank == cardRank.Ace;
            }
        }
        private List<IPlayer> _players { get; set; }
        private Deck _shoe { get; set; }
        private User _user { get; set; }

        public Table(User user)
        {
            Nick = new Dealer();
            Raymond = new Human(user);
            _players = new List<IPlayer>();
            _shoe = new Deck(user.NumDecks);
            Resolved = false;
            _players.Add(Raymond);
            _players.Add(Nick);
            _user = user;
        }

        public void Deal(int bet)
        {
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
        public void CheckTable()
        {
            if (((Human)Raymond).UnresolvedHands.Count == 0)
            {
                ResolveTable();
            }
        }
        public void ResolveTable()
        {
            ResolveDealer();
            ResolvePlayer((Human)Raymond);
            _shoe.Shuffle();
        }
        public void ResolveDealer()
        {
            while(!((Dealer)Nick).Resolved)
            {
                Nick.Hit(_shoe.DealTopCard());
            }

        }
        public void ResolvePlayer(Human c)
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
            }
            PayPlayer((Human)Raymond);
        }
        public void PayPlayer(Human c)
        {
            foreach (HumanHand h in c.ResolvedHands)
            {
                switch (h.State)
                {
                    case handState.BlackJack: _user.Bankroll += h.Bet * 3; break;
                    case handState.Win: _user.Bankroll += h.Bet * 2; break;
                    case handState.Push: _user.Bankroll += h.Bet; break;
                    default: break;
                }
            }
        }
    }
}
