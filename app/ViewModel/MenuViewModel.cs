using CasinoSimulation.Command.Menu;
using CasinoSimulation.Model.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace CasinoSimulation.ViewModel
{
    public class MenuViewModel : ViewModelBase
    {
        public ICommand BlackJackCommand { get; }
        public ICommand SlotsCommand { get; }
        public ICommand RouletteCommand { get; }
        public long Bankroll
        {
            get
            {
                return _user.Bankroll;
            }
            set
            {
                _user.Bankroll = value;
                OnPropertyChanged("Bankroll");
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

        private User _user;

        public MenuViewModel(Navigation nav, User user)
        {
            _user = user;
            Bankroll = user.Bankroll;
            BlackJackCommand = new BlackJackCommand(nav, _user);
            SlotsCommand = new SlotsCommand(nav, _user);
            RouletteCommand = new RouletteCommand(nav, _user);
        }
    }
}
