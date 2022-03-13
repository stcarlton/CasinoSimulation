using CasinoSimulation.Model.Global;
using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Menu
{
    public class BlackJackCommand : NavigationCommand
    {
        public BlackJackCommand(Navigation navigation, User user) : base(navigation, user) { }

        public override void Execute(object parameter)
        {
           _navigation.CurrentViewModel = new BlackJackViewModel(_navigation, _user);
        }
    }
}
