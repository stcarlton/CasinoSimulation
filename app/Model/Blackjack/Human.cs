using CasinoSimulation.Model.Global;
using System.Collections.Generic;

namespace CasinoSimulation.Model.Blackjack
{
    /// <summary>
    /// Defines player data and functions
    /// (Requirement 1.2.2)
    /// </summary>
    public class Human : IPlayer
    {
        public Hand CurrentHand { get; set; }
        public HumanHand PreviousHand
        {
            get
            {
                if (UnresolvedHands.Count > 0)
                {
                    return UnresolvedHands.Peek();
                }
                else if (ResolvedHands.Count > 0)
                {
                    return ResolvedHands.Peek();
                }
                else
                {
                    return null;
                }
            }
        }
        public Stack<HumanHand> UnresolvedHands { get; }
        public Stack<HumanHand> ResolvedHands { get; }
        public long InsuranceBet { get; set; }
        private User _user;
        public Human(User user)
        {
            CurrentHand = null;
            UnresolvedHands = new Stack<HumanHand>();
            ResolvedHands = new Stack<HumanHand>();
            InsuranceBet = 0;
            _user = user;
        }
        //Initializes deal
        //(Requirement 3.2.2.2)
        public void DealIn(long Bet)
        {
            UnresolvedHands.Clear();
            ResolvedHands.Clear();
            _user.Bankroll -= Bet;
            CurrentHand = new HumanHand(Bet);
        }
        //Defines player receiving card
        //(Requirement 3.2.2.4)
        public void Hit(Card c)
        {
            CurrentHand.ReceiveCard(c);
            CheckHuman();
        }
        //Defines player standing
        //(Requirement 3.2.2.5)
        public void Stand()
        {
            if (CurrentHand.State == handState.Unresolved)
            {
                CurrentHand.State = handState.Resolved;
            }
            if (UnresolvedHands.Count > 0)
            {
                ResolvedHands.Push((HumanHand)CurrentHand);
                CurrentHand = UnresolvedHands.Pop();
            }
        }
        //Defines player doubling down
        //(Requirement 3.2.2.6)
        public void DoubleDown(Card c)
        {
            Hit(c);
            _user.Bankroll -= ((HumanHand)CurrentHand).Bet;
            ((HumanHand)CurrentHand).Bet *= 2;
            if (CurrentHand.State == handState.Unresolved)
            {
                Stand();
            }
        }
        //Defines first part of player splitting
        //(Requirement 3.2.2.7)
        public void SplitUp()
        {
            HumanHand _newHand = new HumanHand(((HumanHand)CurrentHand).Bet);
            _user.Bankroll -= ((HumanHand)CurrentHand).Bet;
            _newHand.ReceiveCard(((HumanHand)CurrentHand).TakeCard());
            UnresolvedHands.Push(_newHand);
        }
        //Defines second part of player splitting
        //(Requirement 3.2.2.7)
        public void DealSplit(Card a, Card b)
        {
            CurrentHand.ReceiveCard(a);
            UnresolvedHands.Peek().ReceiveCard(b);
            CheckHuman();
        }
        //Defines insurance payout
        //(Requirement 3.2.1.2.5)
        public void SettleInsurance()
        {
            ((HumanHand)CurrentHand).Winnings += InsuranceBet * 3;
        }
        //Defines automatic resolution of hands
        //(Requirement 3.2.1.2)
        private void CheckHuman()
        {
            if (CurrentHand.State != handState.Unresolved)
            {
                Stand();
            }
        }
    }
}
