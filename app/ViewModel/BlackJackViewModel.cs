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
        public ICommand Menu { get; }
        public ICommand Deal { get; }
        public ICommand Insurance { get; }
        public ICommand Stand { get; }
        public ICommand Hit { get; }
        public ICommand DoubleDown { get; }
        public ICommand Split { get; }
        public ICommand RemoveChip { get; }
        public ICommand NextHand { get; }
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

        public IList<Card> DealerHandDisplay
        {
            get
            {
                IList<Card> cards = new List<Card>();
                for (int i = 0; i < _model.Nick.CurrentHand?.Cards.Count; i++)
                {
                    if (_model.TableState != tableState.settlement && i == 0)
                    {
                        cards.Add(_cardBack);
                    }
                    else
                    {
                        cards.Add(_model.Nick.CurrentHand.Cards[i]);
                    }
                }
                return cards;
            }
        }
        public IList<Card> HumanHandDisplay
        {
            get
            {
                IList<Card> cards = new List<Card>();
                for (int i = 0; i < _model.Raymond.CurrentHand?.Cards.Count; i++)
                {
                    cards.Add(_model.Raymond.CurrentHand.Cards[i]);
                }
                return cards;
            }
        }
        public IList<Chip> BankrollChipDisplay
        {
            get
            {
                return BuildChips(_user.Bankroll);
            }
        }
        public IList<Chip> BetChipDisplay
        {
            get
            {
                return BuildChips(BetValue);
            }
        }
        public IList<Chip> WinningChipDisplay
        {
            get
            {
                long w = (HumanHand)_model.Raymond.CurrentHand == null ? 0 : ((HumanHand)_model.Raymond.CurrentHand).Winnings;
                return BuildChips(w);
            }
        }
        public IList<Chip> InsuranceChipDisplay
        {
            get
            {
                return BuildChips(((Human)_model.Raymond).InsuranceBet);
            }
        }

        public long BankrollDisplay
        {
            get
            {
                return _user.Bankroll;
            }
        }
        public string HandStateDisplay
        {
            get
            {
                return _model.Raymond.CurrentHand?.State.ToString();
            }
        }
        public int MinBet
        {
            get
            {
                return _user.MinBet;
            }
        }
        public int MaxBet
        {
            get
            {
                return _user.MaxBet;
            }
        }
        public int DealerHandValue
        {
            get
            {
                return _model.Nick.CurrentHand == null ? 0 : _model.Nick.CurrentHand.HandValue;
            }
        }
        public int HumanHandValue
        {
            get
            {
                return _model.Raymond.CurrentHand == null ? 0 : _model.Raymond.CurrentHand.HandValue;
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
        public long BetValue
        {
            get
            {
                return _betValue;
            }
            set
            {
                _betValue = value;
                OnPropertyChanged("BetValue");
                OnPropertyChanged("BetChipDisplay");
                OnPropertyChanged("CanBet");
                OnPropertyChanged("CanDeal");
            }
        }
        public long InsuranceBet
        {
            get
            {
                return ((Human)_model.Raymond).InsuranceBet;
            }
        }
        public bool IsBetting
        {
            get
            {
                return _model.TableState == tableState.betting;
            }
        }
        public bool IsOption
        {
            get
            {
                return _model.TableState == tableState.option;
            }
        }
        public bool IsSettlement
        {
            get
            {
                return _model.TableState == tableState.settlement;
            }
        }
        public bool IsNotBetting
        {
            get
            {
                return _model.TableState != tableState.betting;
            }
        }
        public bool CanBet
        {
            get
            {
                return BetValue < _user.MaxBet && BetValue < _user.Bankroll;
            }
        }
        public bool CanDeal
        {
            get
            {
                return BetValue >= _user.MinBet && BetValue <= _user.Bankroll;
            }
        }
        public bool CanBuyInsurance
        {
            get
            {
                if (_model.TableState != tableState.option)
                {
                    return false;
                }
                return _model.InsuranceEligible;
            }
        }
        public bool CanDoubleDown
        {
            get
            {
                if (_model.TableState != tableState.option)
                {
                    return false;
                }
                return ((HumanHand)_model.Raymond.CurrentHand).DoubleDownEligible;
            }
        }
        public bool CanSplit
        {
            get
            {
                if (_model.TableState != tableState.option)
                {
                    return false;
                }
                return ((HumanHand)_model.Raymond.CurrentHand).SplitEligible;
            }
        }
        private Table _model;
        private User _user;
        private long _betValue;
        private Card _cardBack;
        private IList<ICommand> _betCommands;
        private IList<byte[]> _betImages;
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
            NextHand = new NextHandCommand(_model, this);
            Menu = new MenuCommand(navigation, _user);
            _betCommands = new List<ICommand>();
            _betImages = new List<byte[]>();
            BetValue = _user.MinBet;
            _cardBack = new Card("Card_Back_Blue");
            _rm = new ResourceManager("CasinoSimulation.Properties.Resources", Assembly.GetExecutingAssembly());
            for (int i = 0; i < 4; i++)
            {
                int chipIndex = (i > 1 && (int)_user.UserStakes == 10) ? (int)_user.UserStakes - i - 1 : (int)_user.UserStakes - i;
                int chipValue = _user.ChipDenominations[chipIndex];
                _resourceName = chipValue + "_Top";
                _betCommands.Add(new BetCommand(this, chipValue));
                _betImages.Add((byte[])_rm.GetObject(_resourceName));
            }
        }
        
        public void RefreshBankroll()
        {
            OnPropertyChanged("BankrollDisplay");
            OnPropertyChanged("BankrollChipDisplay");
        }
        public void RefreshDealer()
        {
            OnPropertyChanged("DealerHandDisplay");
            OnPropertyChanged("DealerHandValue");
        }
        public void RefreshHuman()
        {
            OnPropertyChanged("HumanHandDisplay");
            OnPropertyChanged("HumanHandValue");
            OnPropertyChanged("HandStateDisplay");
            BetValue = ((HumanHand)_model.Raymond.CurrentHand).Bet;
        }
        public void RefreshWinnings()
        {
            OnPropertyChanged("HandStateDisplay");
            OnPropertyChanged("WinningChipDisplay");
        }
        public void RefreshButtons()
        {
            OnPropertyChanged("IsBetting");
            OnPropertyChanged("IsOption");
            OnPropertyChanged("IsSettlement");
            OnPropertyChanged("IsNotBetting");
            OnPropertyChanged("CanBuyInsurance");
            OnPropertyChanged("CanDoubleDown");
            OnPropertyChanged("CanSplit");
        }
        private IList<Chip> BuildChips(long cash)
        {
            if (cash == 0)
            {
                return null;
            }
            IList<Chip> chips = new List<Chip>();
            foreach (int i in _user.ChipDenominations)
            {

                while (cash >= i)
                {
                    chips.Add(new Chip(i));
                    cash -= i;
                }
            }
            return chips;
        }
    }
}
