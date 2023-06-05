using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace supX.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Variables
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Protected Methods
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "") 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
