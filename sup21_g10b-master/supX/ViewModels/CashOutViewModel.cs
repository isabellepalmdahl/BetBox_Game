namespace supX.ViewModels
{
    public class CashOutViewModel : BaseViewModel
    {

        #region Properties
        public MainViewModel Parent { get; }

        #endregion


        #region Constructors
        public CashOutViewModel(MainViewModel mainViewModel)
        {
            Parent = mainViewModel;

        }
        #endregion


    }
}
