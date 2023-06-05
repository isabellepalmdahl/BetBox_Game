using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Input;
using supX.Commands;
using supX.Models;

namespace supX.ViewModels
{
    public class BackyardViewModel : BaseViewModel
    {
        #region Objects
        Sounds.SoundsAndMusic sounds = new Sounds.SoundsAndMusic();
        #endregion

        #region Variables
        private double privatebalance;
        #endregion

        #region Properties
        public MainViewModel Parent { get; }
        public BettingViewBackyardViewModel Betback { get; set; }
        public FightViewModel Winner { get; set; }
        public ICommand Result { get; set; }
        #endregion

        #region Constructors
        public BackyardViewModel(MainViewModel mainViewModel)
        {
            sounds.PlayFightingSound();
            Parent = mainViewModel;
            Betback = (BettingViewBackyardViewModel)mainViewModel.CurrentViewModel;

            Betback.MyBetId = Betback.GameEngine.SetMyBet(Betback.BetAmount1, Betback.BetAmount2, Betback.FighterId1, Betback.FighterId2);
            Winner = Betback.GameEngine.GenerateResult(Betback.GameEngine.fighter.fighters[Betback.GameEngine.Fighter1.Id], Betback.GameEngine.fighter.fighters[Betback.GameEngine.Fighter2.Id]);
            Betback.GameEngine.BetAmount = Betback.GameEngine.SetBetAmount(Betback.BetAmount1, Betback.BetAmount2);
            Parent.Player.WinnerAmount = Betback.GameEngine.WinnerAmount(Betback.GameEngine.fighter.fighters[Betback.MyBetId], Winner, Parent.Player.MyBalance);
            privatebalance = Betback.GameEngine.CalculateNewBalance(Betback.GameEngine.fighter.fighters[Betback.MyBetId], Winner, Parent.Player.MyBalance);
            Result = new RelyCommand(LostOrWon);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Method that determines if fight is lost, won or game over and sends player to correct view
        /// </summary>
        private void LostOrWon()
        {

            if (privatebalance == 0)
            {
                Parent.CurrentViewModel = new GameOverViewModel(Parent);
            }
            else
            {
                if (Betback.MyBetId == Winner.WinnerId)
                {
                    Parent.CurrentViewModel = new WinnerViewModel(Parent, privatebalance);
                }

                else
                {
                    Parent.CurrentViewModel = new LoserViewModel(Parent, privatebalance);
                }
            }
            
        }
        #endregion

    }
}