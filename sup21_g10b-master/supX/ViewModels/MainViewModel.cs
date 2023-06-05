using supX.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace supX.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Variables
        private PlayerViewModel player;
        #endregion

        #region Properties
        public PlayerViewModel Player
        {
            get { return player; }
            set { player = value; NotifyPropertyChanged(); }
        }

        private MainViewModel gameViewModel;

        public MainViewModel GameViewModel
        {
            get { return gameViewModel; }
            set 
            { gameViewModel = value;
                NotifyPropertyChanged();
            }
        }

        private BaseViewModel currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set 
            { currentViewModel = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand ChangeViewCommand { get; }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            ChangeViewCommand = new ChangeViewCommand(this);
            currentViewModel = new StartViewModel(null);
            ExsistingPlayer();
        }
        #endregion

        #region Private Methods
        private void ExsistingPlayer()
        {
            if (Player == null)
            {
                Player = new PlayerViewModel(this) { MyBalance = 100 };
            }
        }
        #endregion
    }
}
