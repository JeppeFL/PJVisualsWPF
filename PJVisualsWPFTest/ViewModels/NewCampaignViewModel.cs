using PJVisualsWPFTest.Commands;
using PJVisualsWPFTest.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PJVisualsWPFTest.ViewModels
{
    class NewCampaignViewModel : INotifyPropertyChanged
    {

        private Campaign campaign;

        //Customer / CompanyName
        private string customer;
        public string Customer
        {
            get { return customer; }
            set 
            { 
                customer = value;
                OnPropertyChanged("CompanyName");

            }
        }

        //Name
        private string name;

        public string Name
        {
            get { return name; }
            set 
            {
                name = value; 
                OnPropertyChanged("Name");
            }
        }

        //Description
        private string description;

        public string Description
        {
            get { return description; }
            set 
            { 
                description = value;
                OnPropertyChanged("Description");
                
            }
        }

        //Amount
        private double amount;

        public double Amount
        {
            get { return amount; }
            set 
            { 
                amount = value;
                OnPropertyChanged("Amount");

            }
        }

        //DueDate
        private DateTime dueDate;

        public DateTime DueDate
        {
            get { return dueDate; }
            set 
            { 
                dueDate = value;
                OnPropertyChanged("DueDate");

            }
        }
        
        //PaymentStatus
        private bool paymentStatus;

        public bool PaymentStatus
        {
            get { return paymentStatus; }
            set 
            { 
                paymentStatus = value;
                OnPropertyChanged("PaymentStatus");
            }

        }


        public NewCampaignViewModel(Campaign campaign)
        {
            Customer = campaign.Customer;
            Name = campaign.Name;
            Description = campaign.Description;
            Amount = campaign.Amount;
            DueDate = campaign.DueDate;
            PaymentStatus = campaign.PaymentStatus;
            
        }

        public ICommand SaveCampaignCmd { get; set; } = new SaveCampaignCommand();


        private CampaignRepository campaignRepository = new CampaignRepository();

        public ObservableCollection<NewCampaignViewModel> NewCampaignVM { get; set; } = new ObservableCollection<NewCampaignViewModel>();

        public NewCampaignViewModel()
        {
            foreach (Campaign campaign in campaignRepository.GetAll())
            {
                NewCampaignVM.Add(new NewCampaignViewModel(campaign));
            }

        }



        private NewCampaignViewModel selectedCampaign;

        public NewCampaignViewModel SelectedCampaign
        {
            get { return selectedCampaign; }
            set { 
                selectedCampaign = value;
                OnPropertyChanged("SelectedCampaign");
            }
        }




        //EventHandler
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
