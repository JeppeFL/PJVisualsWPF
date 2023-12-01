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
using System.Windows.Shapes;

namespace PJVisualsWPFTest.Views
{
    /// <summary>
    /// Interaction logic for CampaignView.xaml
    /// </summary>
    public partial class CampaignView : Window
    {
        public CampaignView()
        {
            InitializeComponent();
        }

        private void btnNyKampange_Click(object sender, RoutedEventArgs e)
        {
            NewCampaignView newCampaignView = new NewCampaignView();
            newCampaignView.Show();
        }
    }
}
