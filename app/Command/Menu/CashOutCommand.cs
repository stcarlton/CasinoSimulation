namespace CasinoSimulation.Command.Menu
{
    class CashOutCommand : ButtonCommand
    {
        /// <summary>
        /// Exits the game
        /// (Requirement 3.1.1.1.2)
        /// </summary>
        public CashOutCommand()
        {
        }

        public override void Execute(object parameter)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
