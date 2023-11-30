using PJVisualsWPFTest.Views;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PJVisualsWPFTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

     
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CustomerView kundeView = new CustomerView();  
            kundeView.Show();
        }

        private void btnProjekter_Click(object sender, RoutedEventArgs e)
        {
            CampaignView campaignView = new CampaignView();
            campaignView.Show();
        }
    }
}
