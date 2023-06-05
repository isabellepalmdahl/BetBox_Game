using System;
using System.Collections.Generic;
using System.Text;

namespace supX.ViewModels
{
    public class StartViewModel : BaseViewModel
    {
        #region Properties
        public MainViewModel Parent { get;}
        #endregion

        #region Constructors
        public StartViewModel(MainViewModel mainViewModel)
        {
            Parent = mainViewModel;            
        }
        #endregion
    }
}
