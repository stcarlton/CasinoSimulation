using System.Collections.Generic;
using CasinoSimulation.Model.Blackjack;
using CasinoSimulation.Model.Global;
using CasinoSimulation.Command.Blackjack;
using CasinoSimulation.Command.Menu;
using System.Windows.Input;
using System.Resources;
using System.Reflection;

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
        public ICommand RemoveChip { get; }
        public ICommand MenuCommand { get; }

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
        public long BankrollDisplay
        {
            get
            {
                return _bankrollDisplay;
            }
            set
            {
                _bankrollDisplay = value;
                OnPropertyChanged("BankrollDisplay");
            }
        }
        public IList<Chip> ChipstackDisplay
        {
            get
            {
                return _chipstackDisplay;
            }
            set
            {
                _chipstackDisplay = value;
                OnPropertyChanged("ChipStackDisplay");
            }
        }
        public IList<Chip> BetChipDisplay
        {
            get
            {
                return _betChipDisplay;
            }
            set
            {
                _betChipDisplay = value;
                OnPropertyChanged("BetChipDisplay");
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
        public int BetValue
        {
            get
            {
                return _betValue;
            }
            set
            {
                _betValue = value;
                OnPropertyChanged("BetValue");
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
        public ICommand BetFirst
        {
            get
            {
                return _betCommands[0];
            }
        }
        public ICommand BetSecond
        {
            get
            {
                return _betCommands[1];
            }
        }
        public ICommand BetThird
        {
            get
            {
                return _betCommands[2];
            }
        }
        public ICommand BetFourth
        {
            get
            {
                return _betCommands[3];
            }
        }
        public byte[] BetFirstImageData
        {
            get
            {
                return _betImages[0];
            }
        }
        public byte[] BetSecondImageData
        {
            get
            {
                return _betImages[1];
            }
        }
        public byte[] BetThirdImageData
        {
            get
            {
                return _betImages[2];
            }
        }
        public byte[] BetFourthImageData
        {
            get
            {
                return _betImages[3];
            }
        }

        private Table _model;
        private HandDisplay _dealerCards { get; set; }
        private HandDisplay _humanCards { get; set; }
        private ChipDisplay _bankrollChips { get; set; }
        private ChipDisplay _betChips { get; set; }
        private IList<Card> _dealerHandDisplay { get; set; }
        private IList<Card> _humanHandDisplay { get; set; }
        private IList<Chip> _chipstackDisplay { get; set; }
        private IList<Chip> _betChipDisplay { get; set; }
        private string _handStateDisplay { get; set; }
        private int _dealerHandValue { get; set; }
        private int _humanHandValue { get; set; }
        private long _bankrollDisplay { get; set; }
        private int _betValue { get; set; }
        protected User _user { get; set; }
        private IList<ICommand> _betCommands { get; set; }
        private IList<byte[]> _betImages { get; set; }
        private ResourceManager _rm;
        private string _resourceName;

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
            RemoveChip = new RemoveChipCommand(this);
            BankrollDisplay = _user.Bankroll;
            MenuCommand = new MenuCommand(navigation, _user);
            BetValue = user.MinBet;
            _bankrollChips = new ChipDisplay(_user.Bankroll, _user.ChipDenominations);
            ChipstackDisplay = _bankrollChips.Chips;
            _betCommands = new List<ICommand>();
            _betImages = new List<byte[]>();
            _betChips = new ChipDisplay(BetValue, _user.ChipDenominations);
            BetChipDisplay = _betChips.Chips;
            _rm = new ResourceManager("CasinoSimulation.Properties.Resources", Assembly.GetExecutingAssembly());

            for (int i = 0; i < 4; i++)
            {
                int chipIndex = (i > 1 && (int)_user.UserStakes == 10) ? (int)_user.UserStakes - i - 1 : (int)_user.UserStakes - i ;
                int chipValue = _user.ChipDenominations[chipIndex];
                _resourceName = chipValue + "_Top";
                _betCommands.Add(new BetCommand(this, chipValue));
                _betImages.Add((byte[])_rm.GetObject(_resourceName));
            }
        }
        public void RefreshBet()
        {
            _bankrollChips = new ChipDisplay(_user.Bankroll, _user.ChipDenominations);
            _betChips = new ChipDisplay(BetValue, _user.ChipDenominations);
            BankrollDisplay = _user.Bankroll;
            ChipstackDisplay = _bankrollChips.Chips;
            BetChipDisplay = _betChips.Chips;
        }
        public void RefreshTable()
        {
            _dealerCards = new HandDisplay(_model.Nick);
            _humanCards = new HandDisplay(_model.Raymond);
            DealerHandDisplay = _dealerCards.Cards;
            CreatorHandDisplay = _humanCards.Cards;
            ChipstackDisplay = _bankrollChips.Chips;
            BankrollDisplay = _user.Bankroll;
            HandStateDisplay = _model.Raymond.CurrentHand.State.ToString();
            DealerHandValue = _model.Nick.CurrentHand.HandValue;
            CreatorHandValue = _model.Raymond.CurrentHand.HandValue;
        }       
    }
}
