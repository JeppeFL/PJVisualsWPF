using PJVisualsWPFTest.Models;
using PJVisualsWPFTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PJVisualsWPFTest.Commands
{
    public class SaveCampaignCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            bool result = true;
            /*if (parameter is NewCampaignViewModel campaignViewModel)
            {
                if(string.IsNullOrEmpty(campaignViewModel.Customer))
                    result = false;
                if(string.IsNullOrEmpty(campaignViewModel.Name))
                    result = false;
                if(string.IsNullOrEmpty(campaignViewModel.Description))
                    result = false;
                if(double.TryParse(campaignViewModel.Amount.ToString(), out _))
                    result = false;
                if(campaignViewModel.DueDate != DateTime.MinValue)
                    result = false;
                       
            }*/

            return result;
        }

        public void Execute(object? parameter)
        {
            if (parameter is NewCampaignViewModel campaignViewModel)
            {
                try
                {
                    // Save Campaign
                    Campaign newCampaign = new Campaign(
                    new Customer { CompanyName = campaignViewModel.Customer }, // Opret en ny instans af Customer
                    campaignViewModel.Name,
                    campaignViewModel.Description,
                    double.Parse(campaignViewModel.Amount.ToString()),
                    campaignViewModel.DueDate,
                    campaignViewModel.PaymentStatus
                    );

                    CampaignRepository repo = new CampaignRepository();
                    repo.SaveCampaignToFile(newCampaign);

                    // Clear ViewModel properties
                    campaignViewModel.Customer = "";
                    campaignViewModel.Name = "";
                    campaignViewModel.Description = "";
                    campaignViewModel.Amount = 0.0;  // Assuming Amount is of type decimal
                    campaignViewModel.DueDate = DateTime.MinValue;
                    campaignViewModel.PaymentStatus = false;
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., log or display an error message)
                    Console.WriteLine($"Error saving campaign: {ex.Message}");
                }
            }
        }
    }
}
