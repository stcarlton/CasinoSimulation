﻿using CasinoSimulation.Model.Blackjack;
using CasinoSimulation.Model.Global;
using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Blackjack
{
    /// <summary>
    /// Links UI buttons to increase bet in view model; test
    /// </summary>
    public class BetCommand : ButtonCommand
    {
        private BlackJackViewModel _vm;
        private int _bet;

        public BetCommand(BlackJackViewModel vm, int bet)
        {
            _vm = vm;
            _bet = bet;
        }
        public override void Execute(object parameter)
        {
            _vm.ChipSound.Play();
            if (_vm.BetValue + _bet > _vm.MaxBet)
            {
                _vm.BetValue = _vm.MaxBet;
            }
            else
            {
                _vm.BetValue += _bet;
            }
            _vm.RefreshBet();
        }
    }
}