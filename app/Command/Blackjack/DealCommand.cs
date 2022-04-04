using CasinoSimulation.Model.Blackjack;
using CasinoSimulation.ViewModel;
using System.Threading.Tasks;

namespace CasinoSimulation.Command.Blackjack
{   
    public class DealCommand : TableCommand
    {
        public DealCommand(Table model, BlackJackViewModel vm) : base(model, vm) { }
        public override void Execute(object parameter)
        {
            int delayCounter = 0;
            
            _model.DealIn(_vm.BetValue);
            _vm.DealerHandDisplay.Clear();
            _vm.HumanHandDisplay.Clear();
            _vm.RefreshHuman();
            _vm.RefreshDealer();
            _vm.RefreshBankroll();
            _vm.AnimateDeal();
            _vm.ToggleButtons();
            _vm.RefreshButtons();
            _vm.CardSounds.Play();

            foreach(IPlayer p in _model.Players)
            {
                delayCounter += BlackJackViewModel.DELAY_MILLISECONDS;
                _vm.DealCard(delayCounter, p);
            }
            foreach (IPlayer p in _model.Players)
            {
                delayCounter += BlackJackViewModel.DELAY_MILLISECONDS;
                _vm.DealCard(delayCounter, p);
            }

            Task.Delay(delayCounter).ContinueWith(_ =>
            {
                _vm.CardSounds.Stop();
                _vm.ToggleButtons();
                _vm.RefreshButtons();
                _vm.RefreshWinnings();
                _vm.SaveBet();
                _model.CheckTable();
            });
        }
    }
}