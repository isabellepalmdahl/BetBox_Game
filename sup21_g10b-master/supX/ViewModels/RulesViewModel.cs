using System;
using System.Collections.Generic;
using System.Text;

namespace supX.ViewModels
{
    public class RulesViewModel : BaseViewModel
    {
        #region Properties
        public MainViewModel Parent { get; }
        #endregion

        #region Constructors
        public RulesViewModel(MainViewModel mainViewModel)
        {
            Parent = mainViewModel;
        }
        #endregion
    }
}
