using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Input;
using supX.Commands;
using supX.Models;

namespace supX.ViewModels
{
    public class WembleyViewModel : BaseViewModel
    {
        #region Objects
        Sounds.SoundsAndMusic sounds = new Sounds.SoundsAndMusic();
        #endregion

        #region Variables
        private double privatebalance;
        #endregion

        #region Properties
        public MainViewModel Parent { get; }
        public BettingViewWembleyViewModel Betwem { get; set; }
        public FightViewModel Winner { get; set; }
        public ICommand Result { get; set; }
        #endregion

        #region Constructors
        public WembleyViewModel(MainViewModel mainViewModel)
        {
            sounds.PlayFightingSound();
            Parent = mainViewModel;
            Betwem = (BettingViewWembleyViewModel)mainViewModel.CurrentViewModel;
            Betwem.MyBetId = Betwem.GameEngine.SetMyBet(Betwem.BetAmount1, Betwem.BetAmount2, Betwem.FighterId1, Betwem.FighterId2);
            Winner = Betwem.GameEngine.GenerateResult(Betwem.GameEngine.fighter.fighters[Betwem.GameEngine.Fighter1.Id], Betwem.GameEngine.fighter.fighters[Betwem.GameEngine.Fighter2.Id]);
            Betwem.GameEngine.BetAmount = Betwem.GameEngine.SetBetAmount(Betwem.BetAmount1, Betwem.BetAmount2);
            Parent.Player.WinnerAmount = Betwem.GameEngine.WinnerAmount(Betwem.GameEngine.fighter.fighters[Betwem.MyBetId], Winner, Parent.Player.MyBalance);
            privatebalance = Betwem.GameEngine.CalculateNewBalance(Betwem.GameEngine.fighter.fighters[Betwem.MyBetId], Winner, Parent.Player.MyBalance);
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
                if (Betwem.MyBetId == Winner.WinnerId)
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