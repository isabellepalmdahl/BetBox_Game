using System;
using System.Collections.Generic;
using System.Text;

namespace supX.ViewModels
{
    public class InstructionsViewModel : BaseViewModel
    {
        #region Properties
        public MainViewModel Parent { get; }
        #endregion

        #region Constructors
        public InstructionsViewModel(MainViewModel mainViewModel)
        {
            Parent = mainViewModel;
        }
        #endregion
    }
}
