using CasinoSimulation.Model.Blackjack;
using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Blackjack
{
    public class NextHandCommand : TableCommand
    {
        public NextHandCommand(Table model, BlackJackViewModel vm) : base(model, vm) { }
        public override void Execute(object parameter)
        {
            //TODO: add function to pop hand off of Resolved Stack
        }
    }
}