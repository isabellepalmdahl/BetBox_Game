using supX.Data;
using supX.ViewModels;
using supX.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace supX.Commands
{
    /// <summary>
    /// Change views
    /// </summary>
    public class ChangeViewCommand : ICommand
    {
        #region Variables
        public event EventHandler CanExecuteChanged;
        private MainViewModel mainViewModel;
        #endregion

        #region Constructors
        public ChangeViewCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }
        #endregion

        #region Public Methods
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Switch between different views
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            GotoView view = (GotoView)parameter;

            switch(view)
            {
                case GotoView.ArenaView:
                    mainViewModel.CurrentViewModel = new ArenaViewModel(mainViewModel);
                    break;
                case GotoView.BackyardView:
                    mainViewModel.CurrentViewModel = new BackyardViewModel(mainViewModel);
                    break;
                case GotoView.BellagioView:
                    mainViewModel.CurrentViewModel = new BellagioViewModel(mainViewModel);
                    break;
                case GotoView.WembleyView:
                    mainViewModel.CurrentViewModel = new WembleyViewModel(mainViewModel);
                    break;
                case GotoView.BettingViewBellagio:
                    mainViewModel.CurrentViewModel = new BettingViewBellagioViewModel(mainViewModel);
                    break;
                case GotoView.BettingViewBackyard:
                    mainViewModel.CurrentViewModel = new BettingViewBackyardViewModel(mainViewModel);
                    break;
                case GotoView.BettingViewWembley:
                    mainViewModel.CurrentViewModel = new BettingViewWembleyViewModel(mainViewModel);
                    break;
                case GotoView.RulesView:
                    mainViewModel.CurrentViewModel = new RulesViewModel(mainViewModel);
                    break;
                case GotoView.WinnerView:
                    mainViewModel.CurrentViewModel = new WinnerViewModel(mainViewModel);
                    break;
                case GotoView.LoserView:
                    mainViewModel.CurrentViewModel = new LoserViewModel(mainViewModel);
                    break;
                case GotoView.MainView:
                    mainViewModel.CurrentViewModel = new StartViewModel(mainViewModel);
                    break;
                case GotoView.InstructionsView:
                    mainViewModel.CurrentViewModel = new InstructionsViewModel(mainViewModel);
                    break;
                case GotoView.GameOverView:
                    mainViewModel.CurrentViewModel = new GameOverViewModel(mainViewModel);
                    break;
                case GotoView.CashOutView:
                    mainViewModel.CurrentViewModel = new CashOutViewModel(mainViewModel);
                    break;

                default:
                    break;
            }

        }
        #endregion
    }
}
