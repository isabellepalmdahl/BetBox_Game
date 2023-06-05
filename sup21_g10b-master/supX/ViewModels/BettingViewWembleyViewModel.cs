using supX.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using supX.Commands;
using supX.Data;
using System.Windows.Input;

namespace supX.ViewModels
{
    public class BettingViewWembleyViewModel : BaseViewModel
    {
        #region Objects
        Sounds.SoundsAndMusic sounds = new Sounds.SoundsAndMusic();
        #endregion

        #region Properties
        public BettingViewWembleyViewModel betwem;
        public MainViewModel Parent { get; }
        public GameEngineModel GameEngine { get; set; }
        public FighterViewModel FighterVM { get; set; }
        public double BetAmount1 { get; set; }
        public double BetAmount2 { get; set; }
        public int MyBetId { get; set; } = 0;
        public int FighterId1 { get; set; }
        public int FighterId2 { get; set; }
        public bool btnEnabled { get; set; }
        public ICommand CheckEnoughBalance { get; set; }
        #endregion

        #region Constructors
        public BettingViewWembleyViewModel(MainViewModel mainViewModel)
        {
            Parent = mainViewModel;
            sounds.PlayWemblyIntroSound();          
            GameEngine = new GameEngineModel();
            btnEnabled = false;
            FighterVM = new FighterViewModel();
            GameEngine.GenerateArena();
            FighterId1 = GameEngine.Fighter1.Id;
            FighterId2 = GameEngine.Fighter2.Id;
            CheckEnoughBalance = new RelyCommand(EnoughBalance);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Method that checks if player has sufficent balance to place a bet
        /// </summary>
        private void EnoughBalance()
        {
            if (BetAmount1 + BetAmount2 > Parent.Player.MyBalance)
            {
                MessageBox.Show("Your balance is not enough. Try again!");
                BetAmount1 = 0;
                BetAmount2 = 0;
            }
            else
            {
                btnEnabled = true;
                sounds.PlayCashRegisterSound();
            }
        }
        #endregion
    }
}