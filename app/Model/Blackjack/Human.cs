using CasinoSimulation.Model.Global;
using System.Collections.Generic;

namespace CasinoSimulation.Model.Blackjack
{
    public class Human : IPlayer
    {
        public Hand CurrentHand { get; set; }
        public Stack<HumanHand> UnresolvedHands { get; }
        public Stack<HumanHand> ResolvedHands { get; }
        public long InsuranceBet { get; set; }
        private User _user { get; }
        public Human(User user)
        {
            CurrentHand = null;
            UnresolvedHands = new Stack<HumanHand>();
            ResolvedHands = new Stack<HumanHand>();
            InsuranceBet = 0;
            _user = user;
        }

        public void DealIn(long Bet)
        {
            UnresolvedHands.Clear();
            ResolvedHands.Clear();
            _user.Bankroll -= Bet;
            UnresolvedHands.Push(new HumanHand(Bet));
            CurrentHand = UnresolvedHands.Peek();
        }
        public void Hit(Card c)
        {
            CurrentHand.ReceiveCard(c);
            CheckHuman();
        }
        public void Stand()
        {
            ResolvedHands.Push(UnresolvedHands.Pop());
            if(UnresolvedHands.Count > 0)
            {
                CurrentHand = UnresolvedHands.Peek();
            }
        }
        public void DoubleDown(Card c)
        {
            Hit(c);
            _user.Bankroll -= ((HumanHand)CurrentHand).Bet;
            ((HumanHand)CurrentHand).Bet *= 2;
            if(CurrentHand.State == handState.Unresolved)
            {
                Stand();
            }
        }
        public void Split(Card a, Card b)
        {
            HumanHand _newHand = new HumanHand(((HumanHand)CurrentHand).Bet);
            _user.Bankroll -= ((HumanHand)CurrentHand).Bet;
            _newHand.ReceiveCard(((HumanHand)CurrentHand).TakeCard());
            CurrentHand.ReceiveCard(a);
            _newHand.ReceiveCard(b);
            UnresolvedHands.Push(_newHand);
            CurrentHand = _newHand;
        }
        private void CheckHuman()
        {
            if(CurrentHand.State != handState.Unresolved)
            {
                Stand();
            }
        }
    }
}
