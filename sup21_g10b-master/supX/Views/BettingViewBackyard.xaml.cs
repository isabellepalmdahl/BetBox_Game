using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace supX.Views
{
    /// <summary>
    /// Interaction logic for BettingViewBackyard.xaml
    /// </summary>
    public partial class BettingViewBackyard : UserControl
    {
        public BettingViewBackyard()
        {
            InitializeComponent();
        }

        private void txtBetAmount1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBetAmount1.Text != "0")
            {
                txtBetAmount2.Text = "0";
            }
        }

        private void txtBetAmount2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBetAmount2.Text != "0")
            {
                txtBetAmount1.Text = "0";
            }
        }
    }
}
