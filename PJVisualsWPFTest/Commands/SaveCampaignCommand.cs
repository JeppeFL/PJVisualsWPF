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

        //True or false
        public bool CanExecute(object? parameter)
        {
            bool result = true; 
            if (parameter is NewCampaignViewModel campaignViewModel)
            {
                if(string.IsNullOrEmpty(campaignViewModel.Customer)) 
                    result = false;
                if(string.IsNullOrEmpty(campaignViewModel.Name)) 
                    result = false;
                if(string.IsNullOrEmpty(campaignViewModel.Description))
                    result = false;
               
                //Tjekker Amount
                if (campaignViewModel.Amount == null  || campaignViewModel.Amount == 0)
                {
                    result = false;

                }

                //Tjekker DueDate
                if (campaignViewModel.DueDate == DateTime.MinValue)
                {
                    result = false;
                }

                //Tjekker PaymentStatus
                if (!campaignViewModel.PaymentStatus)
                {
                    result = false;
                }
            }
            return result;
        }

        public void Execute(object? parameter) 
        { 
            if (parameter is NewCampaignViewModel campaignViewModel) 
            { 
                //Save Campaign
                Campaign newCampaign = new Campaign(campaignViewModel.Customer, campaignViewModel.Name, campaignViewModel.Description, campaignViewModel.Amount, campaignViewModel.DueDate, campaignViewModel.PaymentStatus);
                CampaignRepository repo = new CampaignRepository();
                repo.SaveCampaignToFile(newCampaign);

                campaignViewModel.Customer = "";
                campaignViewModel.Name = "";
                campaignViewModel.Description = "";
                campaignViewModel.Amount = 0.0;
                campaignViewModel.DueDate = DateTime.MinValue;
                campaignViewModel.PaymentStatus = false; 


            }
        }
    }
}
