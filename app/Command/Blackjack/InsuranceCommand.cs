﻿using CasinoSimulation.Model.Blackjack;
using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Blackjack
{
    /// <summary>
    /// Links UI insurance button with insurance funciton in the model
    /// </summary>
    public class InsuranceCommand : TableCommand
    {
        public InsuranceCommand(Table model, BlackJackViewModel vm) : base(model, vm) { }
        public override void Execute(object parameter)
        {
            _vm.ChipSound.Play();
            _model.PlaceInsuranceBet(_vm.BetValue);
            _vm.RefreshBankroll();
            _vm.RefreshButtons();
            _vm.RefreshDealer();
            _vm.RefreshHuman();
            _vm.RefreshInsurance();
            _vm.RefreshWinnings();
        }
    }
}