using PJVisualsWPFTest.ViewModels;
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
    /// Interaction logic for NewCampaignView.xaml
    /// </summary>
    public partial class NewCampaignView : Window
       
    {

        NewCampaignViewModel ncvm = new NewCampaignViewModel();
        public NewCampaignView()
        {
            InitializeComponent();
            DataContext = ncvm;
        }

        private void btnNyKundeAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbCompanyName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ncvm.Customer = tbCompanyName.Text;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ncvm.Name = tbNameCampaign.Text;
        }

        private void tbAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            double amount;
            if (Double.TryParse(tbAmount.Text, out amount))
            {
                ncvm.Amount = amount;
            }
            else
            {
                
            }

        }

        private void tbDueDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            DateTime dateValue;
            string dateString = "2023-12-06"; // Example date string in a standard format

            if (DateTime.TryParse(dateString, out dateValue))
            {
                // Conversion successful, dateValue now holds the DateTime
            }
            else
            {
                // Handle the case where the string could not be converted.
                // This might be due to an incorrect format or other issues in the string.
            }


        }

        private void tbPaymentStatus_Checked(object sender, RoutedEventArgs e)
        {
            bool? isChecked = tbPaymentStatus.IsChecked;

            // If you want to ensure it's a non-nullable bool
          
        }

        private void tbDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
           ncvm.Description = tbDescription.Text;
        }
    }
}
