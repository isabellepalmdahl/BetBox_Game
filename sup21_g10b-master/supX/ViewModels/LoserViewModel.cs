using System;
using System.Collections.Generic;
using System.Media;
using System.Text;

namespace supX.ViewModels
{
    public class LoserViewModel : BaseViewModel
    {
        #region Objects
        Sounds.SoundsAndMusic sounds = new Sounds.SoundsAndMusic();
        #endregion

        #region Properties
        public MainViewModel Parent { get; }
        #endregion

        #region Constructors
        public LoserViewModel(MainViewModel mainViewModel)
        {
            Parent = mainViewModel;
        }
        public LoserViewModel(MainViewModel mainViewModel, double privatebalance)
        {
            Parent = mainViewModel;
            Parent.Player.MyBalance = privatebalance;
            sounds.PlayLosingGameSound();
        }
        #endregion

    }
}
