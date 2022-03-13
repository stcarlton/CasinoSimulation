using CasinoSimulation.Command.Menu;
using CasinoSimulation.Model.Global;
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
