using System;
using System.Collections.Generic;
using System.Text;

namespace supX.ViewModels
{
    public class PlayerViewModel : BaseViewModel
    {
        #region Properties
        public double MyBalance { get; set; }
        public double WinnerAmount { get; set; }

        public MainViewModel Parent { get; }
        #endregion

        #region Constructor
        public PlayerViewModel(MainViewModel mainViewModel)
        {
            Parent = mainViewModel;
        }
        #endregion

    }

}
