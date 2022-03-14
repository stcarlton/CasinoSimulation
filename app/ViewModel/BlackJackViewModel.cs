using System.Collections.Generic;
using CasinoSimulation.Model.Blackjack;
using CasinoSimulation.Model.Global;
using CasinoSimulation.Command.Blackjack;
using CasinoSimulation.Command.Menu;
using System.Windows.Input;

namespace CasinoSimulation.ViewModel
{
    public class BlackJackViewModel : ViewModelBase
    {
        public ICommand Deal { get; }
        public ICommand Insurance { get; }
        public ICommand Stand { get; }
        public ICommand Hit { get; }
        public ICommand DoubleDown { get; }
        public ICommand Split { get; }
        public ICommand MenuCommand { get; }

        public int BetValue { get; set; }        
        public IList<Card> DealerHandDisplay
        {
            get
            {
                return _dealerHandDisplay;
            }
            set
            {
                _dealerHandDisplay = value;
                OnPropertyChanged("DealerHandDisplay");
            }
        }
        public IList<Card> CreatorHandDisplay
        {
            get
            {
                return _humanHandDisplay;
            }
            set
            {
                _humanHandDisplay = value;
                OnPropertyChanged("CreatorHandDisplay");
            }
        }
        public long BetDisplay
        {
            get
            {
                return _betDisplay;
            }
            set
            {
                _betDisplay = value;
                OnPropertyChanged("BetDisplay");
            }
        }
        public long ChipStackDisplay
        {
            get
            {
                return _bankrollDisplay;
            }
            set
            {
                _bankrollDisplay = value;
                OnPropertyChanged("ChipStackDisplay");
            }
        }
        public string HandStateDisplay
        {
            get
            {
                return _handStateDisplay;
            }
            set
            {
                _handStateDisplay = value;
                OnPropertyChanged("HandStateDisplay");
            }
        }
        public int DealerHandValue
        {
            get
            {
                return _dealerHandValue;
            }
            set
            {
                _dealerHandValue = value;
                OnPropertyChanged("DealerHandValue");
            }
        }
        public int CreatorHandValue
        {
            get
            {
                return _humanHandValue;
            }
            set
            {
                _humanHandValue = value;
                OnPropertyChanged("CreatorHandValue");
            }
        }
        private Table _model;
        private HandDisplay _dealerCards { get; set; }
        private HandDisplay _humanCards { get; set; }
        private IList<Card> _dealerHandDisplay { get; set; }
        private IList<Card> _humanHandDisplay { get; set; }
        private long _betDisplay { get; set; }
        private string _handStateDisplay { get; set; }
        private int _dealerHandValue { get; set; }
        private int _humanHandValue { get; set; }
        private long _bankrollDisplay { get; set; }
        private User _user { get; set; }

        public BlackJackViewModel(Navigation navigation, User user)
        {
            _model = new Table(user);
            _user = user;
            Deal = new DealCommand(_model, this);
            Insurance = new InsuranceCommand(_model, this);
            Stand = new StandCommand(_model, this);
            Hit = new HitCommand(_model, this);
            DoubleDown = new DoubleDownCommand(_model, this);
            Split = new SplitCommand(_model, this);
            ChipStackDisplay = _user.Bankroll;
            MenuCommand = new MenuCommand(navigation, _user);
        }
        public void RefreshData()
        {
            _dealerCards = new HandDisplay(_model.Nick);
            _humanCards = new HandDisplay(_model.Raymond);
            DealerHandDisplay = _dealerCards.Cards;
            CreatorHandDisplay = _humanCards.Cards;
            BetDisplay = ((Human)_model.Raymond).UnresolvedHands.Count > 0 ? BetDisplay = ((HumanHand)_model.Raymond.CurrentHand).Bet : 0;
            ChipStackDisplay = _user.Bankroll;
            HandStateDisplay = _model.Raymond.CurrentHand.State.ToString();
            DealerHandValue = _model.Nick.CurrentHand.HandValue;
            CreatorHandValue = _model.Raymond.CurrentHand.HandValue;
        }       
    }
}
