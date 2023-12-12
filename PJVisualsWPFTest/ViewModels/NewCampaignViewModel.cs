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

        private string customer;

        public string Customer
        {
            get { return customer; }
            set
            {
                customer = value;
                OnPropertyChanged("Customer");
            }
        }

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
        public NewCampaignViewModel()
        {
            // Initialisér ViewModel som ønsket uden at kræve en eksisterende kampagne.
        }

        public NewCampaignViewModel(Campaign campaign)
        {
            Customer = campaign.CustomerCampaign;
            Name = campaign.Name;
            Description = campaign.Description;
            Amount = campaign.Amount;
            DueDate = campaign.DueDate;
            PaymentStatus = campaign.PaymentStatus;
            this.campaign = campaign;

            //SaveCampaignCmd = new SaveCampaignCommand();
        }

        //public ICommand SaveCampaignCmd { get; set; } = new SaveCampaignCommand();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<NewCampaignViewModel> NewCampaignVM { get; set; } = new ObservableCollection<NewCampaignViewModel>();
    }
}
