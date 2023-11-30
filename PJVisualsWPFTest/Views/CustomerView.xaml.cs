using PJVisualsWPFTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PJVisualsWPFTest.Views
{
    /// <summary>
    /// Interaction logic for KundeView.xaml
    /// </summary>
    public partial class CustomerView : Window
    {
        
        NewCustomerViewModel nkvm = new NewCustomerViewModel();
        
        public CustomerView()
        {
            
            InitializeComponent();
            DataContext = nkvm;

        }

        private void btnNyKunde_Click(object sender, RoutedEventArgs e)
        {

            NewCustomerView newCampaignView = new NewCustomerView();
            newCampaignView.Show();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
