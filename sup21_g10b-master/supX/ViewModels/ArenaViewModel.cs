using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace supX.ViewModels
{
    public class ArenaViewModel : BaseViewModel
    {
        #region Objects
        Sounds.SoundsAndMusic sounds = new Sounds.SoundsAndMusic();
        #endregion

        #region Properties
        public MainViewModel Parent { get; }
        #endregion

        #region Constructors
        public ArenaViewModel(MainViewModel mainViewModel)
        {
            Parent = mainViewModel;
            sounds.PlayArenaIntroSound();                        
        }
        #endregion
    }
}
