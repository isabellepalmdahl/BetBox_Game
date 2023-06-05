using supX.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace supX.ViewModels
{
    public class GameOverViewModel : BaseViewModel
    {
        #region Objects
        Sounds.SoundsAndMusic sounds = new Sounds.SoundsAndMusic();
        #endregion

        #region Properties
        public MainViewModel Parent { get; }
        #endregion

        #region Constructors
        public GameOverViewModel(MainViewModel mainViewModel)
        {
            Parent = mainViewModel;
            sounds.PlayGameOverSound();
            Parent.Player.MyBalance = 100;
        }
        #endregion
    }
}
