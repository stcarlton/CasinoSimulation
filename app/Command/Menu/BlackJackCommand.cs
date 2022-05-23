using CasinoSimulation.Model.Global;
using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Menu
{
    /// <summary>
    /// Command to navigate between menu and blackjack
    /// (Requirement 3.1)
    /// </summary>
    public class BlackJackCommand : NavigationCommand
    {
        public BlackJackCommand(Navigation navigation, User user) : base(navigation, user) { }

        public override void Execute(object parameter)
        {
            _navigation.CurrentViewModel = new BlackJackViewModel(_navigation, _user);
        }
    }
}
