using CasinoSimulation.Command.Menu;
using CasinoSimulation.Model.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace CasinoSimulation.ViewModel
{
    /// <summary>
    /// Opening screen
    /// displays options to get chips, enter a mini game or exit the game
    /// (Requirement 3.1)
    /// </summary>
    public class MenuViewModel : ViewModelBase
    {
        public ICommand CashInCommand { get; }
        public ICommand BlackJackCommand { get; }
        public ICommand SlotsCommand { get; }
        public ICommand RouletteCommand { get; }
        public ICommand CashOutCommand { get; }
        public IList<Chip> BankrollChipDisplay
        {
            get
            {
                return BuildChips(_user.Bankroll);
            }
        }
        public long BankrollDisplay
        {
            get
            {
                return _user.Bankroll;
            }
        }
        public stakes UserStakes
        {
            get
            {
                return _user.UserStakes;
            }
            set
            {
                _user.UserStakes = value;
                OnPropertyChanged("Stakes");
            }
        }
        public IEnumerable<stakes> StakesValues
        {
            get
            {
                return Enum.GetValues(typeof(stakes)).Cast<stakes>();
            }
        }
        public bool CanNavigate
        {
            get
            {
                return _user.Bankroll > 0;
            }
        }

        private User _user;

        public MenuViewModel(Navigation nav, User user)
        {
            _user = user;
            CashInCommand = new CashInCommand(this, _user);
            BlackJackCommand = new BlackJackCommand(nav, _user);
            SlotsCommand = new SlotsCommand(nav, _user);
            RouletteCommand = new RouletteCommand(nav, _user);
            CashOutCommand = new CashOutCommand();
        }
        public void RefreshChipStack()
        {
            OnPropertyChanged("BankrollDisplay");
            OnPropertyChanged("BankrollChipDisplay");
            OnPropertyChanged("CanNavigate");
        }
        private IList<Chip> BuildChips(long cash)
        {
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
