using System;
using System.Collections.Generic;
using System.Text;

namespace supX.ViewModels
{
    public class WinnerViewModel : BaseViewModel
    {
        #region Objects
        Sounds.SoundsAndMusic sounds = new Sounds.SoundsAndMusic();
        #endregion

        #region Properties
        public MainViewModel Parent { get; }
        #endregion

        #region Constructors
        public WinnerViewModel(MainViewModel mainViewModel)
        {
            Parent = mainViewModel;            
        }

        public WinnerViewModel(MainViewModel mainViewModel, double privatebalance)
        {
            Parent = mainViewModel;
            Parent.Player.MyBalance = privatebalance;
            sounds.PlayWinnerGameSound();
        }
        #endregion
    }
}
